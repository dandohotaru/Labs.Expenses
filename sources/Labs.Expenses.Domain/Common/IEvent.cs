using System;

namespace Labs.Expenses.Domain.Common
{
    public interface IEvent : IMessage
    {
        DateTimeOffset Timestamp { get; }
    }
}