using System;

namespace Labs.Expenses.R.Domain.Common
{
    public abstract class Entity
        : IEntity
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public byte[] Version { get; set; }
    }
}