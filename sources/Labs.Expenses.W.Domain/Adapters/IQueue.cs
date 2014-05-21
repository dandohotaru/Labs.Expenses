using System;
using System.Collections.Generic;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface IQueue : IDisposable
    {
        void Enqueue(IEvent message);

        IEnumerable<IEvent> Dequeue();
    }
}