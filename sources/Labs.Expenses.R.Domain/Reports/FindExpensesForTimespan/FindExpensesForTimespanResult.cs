using System.Collections.Generic;
using Labs.Expenses.R.Domain.Common;

namespace Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan
{
    public class FindExpensesForTimespanResult : Result
    {
        public List<ExpenseModel> Expenses { get; set; }
    }
}