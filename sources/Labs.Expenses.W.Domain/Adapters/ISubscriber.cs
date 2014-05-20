using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface ISubscriber
    {
        void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;
    }
}