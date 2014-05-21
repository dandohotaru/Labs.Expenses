using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Events
{
    public class ExpenseRemovedEvent : Event
    {
        public Guid ExpenseId { get; set; }
    }
}