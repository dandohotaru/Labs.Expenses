using System;
using Labs.Expenses.W.Adapters.Queues;
using Labs.Expenses.W.Data.Contexts;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Values;
using Labs.Expenses.W.Tests.Facades;
using Ninject.Modules;

namespace Labs.Expenses.W.Tests.Bootstrap
{
    public class ExpensesModule : NinjectModule
    {
        public override void Load()
        {
            // Builders
            Bind<ITenant>().To<SystemTenant>();
            Bind<IPolicy>().To<SystemPolicy>();

            // Adapters
            Bind<IEventBus>().To<MemoryEventBus>().InSingletonScope();
            Bind<Func<IDataContext>>().ToMethod(context => () => new SqlContext());

            // Services
            Bind<IExpensesFacade>().To<ExpensesFacade>();
        }
    }
}