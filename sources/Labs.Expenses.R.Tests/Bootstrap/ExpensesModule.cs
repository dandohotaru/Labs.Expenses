using System;
using Labs.Expenses.R.Data.Contexts;
using Labs.Expenses.R.Domain;
using Labs.Expenses.R.Domain.Adapters;
using Ninject.Modules;

namespace Labs.Expenses.R.Tests.Bootstrap
{
    public class ExpensesModule : NinjectModule
    {
        public override void Load()
        {
            // Adapters
            Bind<Func<ISession>>().ToMethod(context => () => new SqlSession());

            // Services
            Bind<ISearchFacade>().To<SearchFacade>();
        }
    }
}