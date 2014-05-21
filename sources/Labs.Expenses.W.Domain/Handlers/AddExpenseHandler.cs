using System;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Entities;
using Labs.Expenses.W.Domain.Events;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Handlers
{
    public class AddExpenseHandler : IHandler<AddExpenseCommand>
    {
        public AddExpenseHandler(ISession session, IQueue changes)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            if (changes == null)
                throw new ArgumentNullException("changes");

            Session = session;
            Changes = changes;
        }

        protected ISession Session { get; private set; }

        protected IQueue Changes { get; private set; }

        public void Execute(AddExpenseCommand command)
        {
            if (command.PurchaseDate == null)
                throw new ArgumentException("command.PurchaseDate is required");
            if (command.Amount == null)
                throw new ArgumentException("command.Amount is required");

            var expense = Session.Find<Expense>(command.ExpenseId);
            if (expense != null)
                throw new Exception("The provided expense already exists in the data store.");

            var merchant = Session
                .Query<Merchant>()
                .SingleOrDefault(p => p.Name.ToLower() == command.Merchant.ToLower());
            if (merchant == null)
            {
                merchant = new Merchant
                {
                    Id = Guid.NewGuid(),
                    TenantId = command.TenantId,
                    Name = command.Merchant,
                };

                Session.Add(merchant);
            }

            expense = new Expense
            {
                Id = command.ExpenseId,
                TenantId = command.TenantId,
                PolicyId = command.PolicyId,
                Date = command.PurchaseDate.Value,
                Amount = command.Amount.Value,
                Vat = command.Vat,
                MerchantId = merchant.Id,
            };

            Session.Add(expense);

            Changes.Enqueue(new ExpenseAddedEvent
            {
                TenantId = command.TenantId,
                CorrelationId = command.CommandId,
                Timestamp = SystemTime.Now(),
            });
        }
    }
}