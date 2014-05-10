using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface IResult : IMessage
    {
        Guid CommandId { get; }

        Guid TenantId { get; }

        DateTimeOffset Timestamp { get; }
    }
}