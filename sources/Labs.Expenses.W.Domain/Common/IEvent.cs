using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface IEvent : IMessage
    {
        Guid RootId { get; set; }

        Guid TenantId { get; set; }

        Guid CorrelationId { get; set; }

        DateTimeOffset Timestamp { get; set; }
    }
}