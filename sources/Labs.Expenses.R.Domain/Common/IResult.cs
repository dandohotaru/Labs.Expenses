using System;

namespace Labs.Expenses.R.Domain.Common
{
    public interface IResult : IMessage
    {
        Guid QueryId { get; }

        Guid TenantId { get; }

        DateTimeOffset Timestamp { get; }
    }
}