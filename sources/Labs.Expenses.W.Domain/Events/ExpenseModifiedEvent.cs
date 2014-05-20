using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Events
{
    public class ExpenseModifiedEvent : Event
    {
        public ExpenseModifiedEvent(Guid rootId, Guid correlationId) 
            : base(rootId, correlationId)
        {
        }
    }
}