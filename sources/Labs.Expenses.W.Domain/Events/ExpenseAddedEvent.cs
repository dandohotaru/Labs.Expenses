﻿using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Events
{
    public class ExpenseAddedEvent : Event
    {
        public ExpenseAddedEvent(Guid rootId, Guid correlationId) 
            : base(rootId, correlationId)
        {
        }
    }
}