using System;

namespace Labs.Expenses.Domain.Common
{
    public interface ICommand : IMessage
    {
        Guid CommandId { get; }

        Guid TenantId { get; }

        DateTimeOffset Timestamp { get; }
    }
}