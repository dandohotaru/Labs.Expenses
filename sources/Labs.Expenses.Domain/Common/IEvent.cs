using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface IEvent : IMessage
    {
        DateTimeOffset Timestamp { get; }
    }
}