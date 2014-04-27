using System;

namespace Labs.Expenses.W.Domain.Common
{
    public abstract class Entity
        : IEntity, IEntityWithId, IEntityWithTenantId
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public byte[] Version { get; set; }
    }
}