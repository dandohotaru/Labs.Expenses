using System;
using Labs.Expenses.R.Domain.Adapters;
using Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan;

namespace Labs.Expenses.R.Domain
{
    public class SearchFacade : ISearchFacade
    {
        public SearchFacade(Func<ISession> sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");

            SessionFactory = sessionFactory;
        }

        protected Func<ISession> SessionFactory { get; private set; }

        public FindExpensesForTimespanResult Execute(FindExpensesForTimespanQuery query)
        {
            using (var session = SessionFactory())
            {
                var handler = new FindExpensesForTimespanHandler(session);
                return handler.Execute(query);
            }
        }
    }
}