using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface IEntity
    {
    }

    public interface IEntityWithId
    {
        Guid Id { get; }
    }

    public interface IEntityWithTenantId
    {
        Guid TenantId { get; }
    }
}