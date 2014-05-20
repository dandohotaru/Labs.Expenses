using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface ICommand : IMessage
    {
        Guid RootId { get; }

        Guid CommandId { get; }

        Guid TenantId { get; }

        DateTimeOffset Timestamp { get; }
    }
}