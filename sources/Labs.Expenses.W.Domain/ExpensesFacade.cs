using System;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Handlers;

namespace Labs.Expenses.W.Domain
{
    public class ExpensesFacade : IExpensesFacade
    {
        public ExpensesFacade(Func<ISession> sessionFactory, Func<IQueue> changesFactory, IPublisher publisher)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            if (changesFactory == null)
                throw new ArgumentNullException("changesFactory");
            if (publisher == null)
                throw new ArgumentNullException("publisher");

            SessionFactory = sessionFactory;
            ChangesFactory = changesFactory;
            Publisher = publisher;
        }

        protected Func<ISession> SessionFactory { get; private set; }

        protected Func<IQueue> ChangesFactory { get; private set; }

        protected IPublisher Publisher { get; private set; }

        public void AddExpense(AddExpenseCommand command)
        {
            using (var session = SessionFactory())
            using (var changes = ChangesFactory())
            {
                var handler = new AddExpenseHandler(session, changes);
                handler.Execute(command);
                session.Save();

                Publisher.Publish(changes.Dequeue());
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

                Publisher.Publish(changes.Dequeue());
            }
        }

        public void RemoveExpense(RemoveExpenseCommand command)
        {
            using (var session = SessionFactory())
            using (var changes = ChangesFactory())
            {
                var handler = new RemoveExpenseHandler(session, changes);
                handler.Execute(command);
                session.Save();

                Publisher.Publish(changes.Dequeue());
            }
        }
    }
}