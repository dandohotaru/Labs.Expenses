using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Common
{
    public class Event : IEvent
    {
        public Event(Guid rootId, Guid correlationId)
        {
            if (rootId == default(Guid))
                throw new ArgumentException("RootId");
            if (correlationId == default(Guid))
                throw new ArgumentException("correlationId");

            RootId = rootId;
            CorrelationId = correlationId;
            Timestamp = SystemTime.Now();
        }

        [Required]
        public Guid RootId { get; set; }

        [Required]
        public Guid CorrelationId { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}