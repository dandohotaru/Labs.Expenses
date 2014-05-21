using System;
using Labs.Expenses.R.Domain.Common;

namespace Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan
{
    public class FindExpensesForTimespanQuery : Query
    {
        public DateTimeOffset? Start { get; set; }

        public DateTimeOffset? End { get; set; }
    }
}