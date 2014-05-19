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
        public AddExpenseHandler(IDataContext context, IEventBus bus)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (bus == null)
                throw new ArgumentNullException("bus");

            Context = context;
            Bus = bus;
        }

        protected IDataContext Context { get; private set; }

        protected IEventBus Bus { get; private set; }

        public void Execute(AddExpenseCommand command)
        {
            if (command.PurchaseDate == null)
                throw new ArgumentException("command.PurchaseDate is required");
            if (command.Amount == null)
                throw new ArgumentException("command.Amount is required");

            var expense = Context.Find<Expense>(command.ExpenseId);
            if (expense != null)
                throw new Exception("The provided expense already exists in the data store.");

            var merchant = Context
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

                Context.Add(merchant);
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

            Context.Add(expense);

            Bus.Publish(new ExpenseAddedEvent
            {
                TenantId = command.TenantId,
                CorrelationId = command.CommandId,
                Timestamp = SystemTime.Now(),
            });
        }
    }
}