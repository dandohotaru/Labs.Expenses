﻿using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface IEvent : IMessage
    {
        Guid TenantId { get; set; }

        Guid CorrelationId { get; set; }

        DateTimeOffset Timestamp { get; set; }
    }
}