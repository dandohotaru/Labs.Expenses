﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.W.Domain.Common
{
    public class Event : IEvent
    {
        [Required]
        public Guid CorrelationId { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}