using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent e) where TEvent : IEvent;

        void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;
    }
}