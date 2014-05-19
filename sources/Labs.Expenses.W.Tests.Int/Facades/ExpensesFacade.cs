using System;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Handlers;

namespace Labs.Expenses.W.Tests.Facades
{
    public class ExpensesFacade : IExpensesFacade
    {
        public ExpensesFacade(Func<IDataContext> storage, IEventBus eventBus)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (eventBus == null)
                throw new ArgumentNullException("eventBus");

            Storage = storage;
            EventBus = eventBus;
        }

        protected Func<IDataContext> Storage { get; private set; }

        protected IEventBus EventBus { get; private set; }

        public void AddExpense(AddExpenseCommand command)
        {
            using (var context = Storage())
            {
                var handler = new AddExpenseHandler(context, EventBus);
                handler.Execute(command);
            }
        }
    }
}