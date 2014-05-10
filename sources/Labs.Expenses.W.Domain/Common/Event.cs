using System;

namespace Labs.Expenses.W.Domain.Common
{
    public class Event : IEvent
    {
        public Guid TenantId { get; set; }

        public Guid CorrelationId { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}