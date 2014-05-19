using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Adapters.Queues
{
    public class MemoryEventBus : IEventBus
    {
        public MemoryEventBus()
        {
            Handlers = new Dictionary<Type, List<Action<IEvent>>>();
        }

        protected IDictionary<Type, List<Action<IEvent>>> Handlers { get; private set; }

        public void Publish<TEvent>(TEvent e)
            where TEvent : IEvent
        {
            var eventType = typeof (TEvent);

            var actions = from handler in Handlers
                where handler.Key.IsAssignableFrom(eventType)
                from action in handler.Value
                select action;

            foreach (var action in actions)
            {
                action(e);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> action)
            where TEvent : IEvent
        {
            var eventType = typeof (TEvent);
            if (!Handlers.ContainsKey(eventType))
                Handlers.Add(eventType, new List<Action<IEvent>>());

            Handlers[eventType].Add(e => action((TEvent) e));
        }
    }
}