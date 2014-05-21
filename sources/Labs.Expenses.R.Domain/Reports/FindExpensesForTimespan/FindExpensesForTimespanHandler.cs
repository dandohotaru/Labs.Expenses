using System;
using System.Linq;
using Labs.Expenses.R.Domain.Adapters;
using Labs.Expenses.R.Domain.Common;
using Labs.Expenses.R.Domain.Entities;

namespace Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan
{
    public class FindExpensesForTimespanHandler : IHandler<FindExpensesForTimespanQuery, FindExpensesForTimespanResult>
    {
        public FindExpensesForTimespanHandler(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            Session = session;
        }

        protected ISession Session { get; private set; }

        public FindExpensesForTimespanResult Execute(FindExpensesForTimespanQuery request)
        {
            var query = from expense in Session.Query<Expense>()
                let merchant = expense.Merchant
                let tags = expense.Tags.Select(p => p.Name).ToList()
                let result = new ExpenseModel
                {
                    ExpenseId = expense.Id,
                    Amount = expense.Amount,
                    PurchaseDate = expense.Date,
                    Vat = expense.Vat,
                    Tags = tags,
                    MerchantId = merchant.Id,
                    MerchantName = merchant.Name,
                }
                select result;

            return new FindExpensesForTimespanResult
            {
                Expenses = query.ToList()
            };
        }
    }
}