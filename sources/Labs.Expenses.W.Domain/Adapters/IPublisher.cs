using System.Collections.Generic;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface IPublisher
    {
        void Publish<TEvent>(TEvent message) where TEvent : IEvent;

        void Publish<TEvent>(IEnumerable<TEvent> messages) where TEvent : IEvent;
    }
}