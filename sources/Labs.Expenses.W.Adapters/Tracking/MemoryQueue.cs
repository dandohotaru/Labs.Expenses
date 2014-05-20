using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Adapters.Tracking
{
    public class MemoryQueue : IQueue
    {
        public MemoryQueue()
        {
            Items = new Dictionary<Guid, Queue<IEvent>>();
        }

        protected IDictionary<Guid, Queue<IEvent>> Items { get; private set; }

        public void Enqueue(IEvent e)
        {
            Queue<IEvent> events;
            var exists = Items.TryGetValue(e.ContextId, out events);
            if (!exists)
            {
                events = new Queue<IEvent>();
                Items[e.ContextId] = events;
            }

            events.Enqueue(e);
        }

        public IEnumerable<IEvent> Dequeue(Guid contextId)
        {
            Queue<IEvent> events;
            var exists = Items.TryGetValue(contextId, out events);
            if (!exists)
            {
                var message = string.Format("There were no items found for key {0}.", contextId);
                throw new Exception(message);
            }

            var e = events.Dequeue();
            while (e != null)
            {
                yield return e;

                e = events.Any() 
                    ? events.Dequeue()
                    : null;
            }
        }

        public void Dispose()
        {
            Items = null;
        }
    }
}