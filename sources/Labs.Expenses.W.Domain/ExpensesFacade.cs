using System;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Handlers;

namespace Labs.Expenses.W.Domain
{
    public class ExpensesFacade : IExpensesFacade
    {
        public ExpensesFacade(Func<ISession> sessionFactory, Func<IQueue> changesFactory, IBus bus)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            if (changesFactory == null)
                throw new ArgumentNullException("changesFactory");
            if (bus == null)
                throw new ArgumentNullException("bus");

            SessionFactory = sessionFactory;
            ChangesFactory = changesFactory;
            Bus = bus;
        }

        protected Func<ISession> SessionFactory { get; private set; }

        protected Func<IQueue> ChangesFactory { get; private set; }

        protected IBus Bus { get; private set; }

        public void AddExpense(AddExpenseCommand command)
        {
            using (var session = SessionFactory())
            using (var changes = ChangesFactory())
            {
                var handler = new AddExpenseHandler(session, changes);
                handler.Execute(command);
                session.Save();

                var events = changes.Dequeue(command.RootId).ToList();
                events.ForEach(e => Bus.Publish(e));
            }
        }

        public void ModifyExpense(ModifyExpenseCommand command)
        {
            using (var session = SessionFactory())
            using (var changes = ChangesFactory())
            {
                var handler = new ModifyExpenseHandler(session, changes);
                handler.Execute(command);
                session.Save();

                var events = changes.Dequeue(command.RootId).ToList();
                events.ForEach(e => Bus.Publish(e));
            }
        }
    }
}