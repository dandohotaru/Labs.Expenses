using System;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Entities;
using Labs.Expenses.W.Domain.Events;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Handlers
{
    public class RemoveExpenseHandler : IHandle<RemoveExpenseCommand>
    {
        public RemoveExpenseHandler(ISession session, IQueue changes)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            if (changes == null)
                throw new ArgumentNullException("changes");

            Session = session;
            Changes = changes;
        }

        protected ISession Session { get; private set; }

        protected IQueue Changes { get; private set; }

        public void Execute(RemoveExpenseCommand command)
        {
            if (command.ExpenseId == null)
                throw new ArgumentException("command.ExpenseId is required");

            var expense = Session.Find<Expense>(command.ExpenseId);
            if (expense == null)
                throw new Exception("The provided expense does not exist in the data store.");

            Session.Remove(expense);

            Changes.Enqueue(new ExpenseRemovedEvent
            {
                ExpenseId = command.ExpenseId,
                TenantId = command.TenantId,
                CorrelationId = command.CommandId,
                Timestamp = SystemTime.Now(),
            });
        }
    }
}