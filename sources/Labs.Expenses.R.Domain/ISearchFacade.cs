using Labs.Expenses.R.Domain.Common;
using Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan;

namespace Labs.Expenses.R.Domain
{
    public interface ISearchFacade :
        IHandle<FindExpensesForTimespanQuery, FindExpensesForTimespanResult>
    {
    }
}