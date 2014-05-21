using Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan;

namespace Labs.Expenses.R.Domain
{
    public interface ISearchFacade
    {
        FindExpensesForTimespanResult Find(FindExpensesForTimespanQuery query);
    }
}