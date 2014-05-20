using System;
using Labs.Expenses.W.Adapters.Tracking;
using Labs.Expenses.W.Data.Contexts;
using Labs.Expenses.W.Domain;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Values;
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
            Bind<IBus>().To<MemoryBus>().InSingletonScope();
            Bind<Func<IQueue>>().ToMethod(queue => () => new MemoryQueue());
            Bind<Func<ISession>>().ToMethod(context => () => new SqlSession());

            // Services
            Bind<IExpensesFacade>().To<ExpensesFacade>();
        }
    }
}