using System;

namespace Labs.Expenses.Domain.Common
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