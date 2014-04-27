using System;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Domain.Handlers
{
    public class AddExpenseHandler : IHandler<AddExpenseCommand, AddExpenseResult>
    {
        public AddExpenseHandler(IDataContext dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            DataContext = dataContext;
        }

        protected IDataContext DataContext { get; private set; }

        public AddExpenseResult Execute(AddExpenseCommand command)
        {
            if (command.PurchaseDate == null)
                throw new ArgumentException("command.PurchaseDate is required");
            if (command.Amount == null)
                throw new ArgumentException("command.Amount is required");

            var expense = DataContext.Find<Expense>(command.ExpenseId);
            if (expense != null)
                throw new Exception("The provided expense already exists in the data store.");

            var merchant = DataContext
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
                DataContext.Add(merchant);
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

            DataContext.Add(expense);

            return new AddExpenseResult(command.CommandId, command.TenantId);
        }
    }
}