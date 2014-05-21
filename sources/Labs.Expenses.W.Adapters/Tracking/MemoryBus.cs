using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Adapters.Tracking
{
    public class MemoryBus : IBus
    {
        public MemoryBus()
        {
            Handlers = new Dictionary<Type, List<Action<IEvent>>>();
        }

        protected IDictionary<Type, List<Action<IEvent>>> Handlers { get; private set; }

        public void Publish<TEvent>(TEvent message)
            where TEvent : IEvent
        {
            var eventType = message.GetType();

            var actions = from handler in Handlers
                where handler.Key.IsAssignableFrom(eventType)
                from action in handler.Value
                select action;

            foreach (var action in actions)
            {
                action(message);
            }
        }

        public void Publish<TEvent>(IEnumerable<TEvent> messages)
            where TEvent : IEvent
        {
            foreach (var message in messages)
            {
                Publish(message);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> action)
            where TEvent : IEvent
        {
            var eventType = typeof (TEvent);
            if (!Handlers.ContainsKey(eventType))
                Handlers.Add(eventType, new List<Action<IEvent>>());

            Handlers[eventType].Add(message => action((TEvent)message));
        }
    }
}