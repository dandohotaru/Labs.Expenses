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
            Items = new Queue<IEvent>();
        }

        protected Queue<IEvent> Items { get; private set; }

        public void Enqueue(IEvent message)
        {
            Items.Enqueue(message);
        }

        public IEnumerable<IEvent> Dequeue()
        {
            var message = Items.Dequeue();
            while (message != null)
            {
                yield return message;

                message = Items.Any()
                    ? Items.Dequeue()
                    : null;
            }
        }

        public void Dispose()
        {
            Items = null;
        }
    }
}