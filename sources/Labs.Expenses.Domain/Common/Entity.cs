using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Expenses.Domain.Common
{
    public abstract class Entity : IEntity, IEntityWithId, IEntityWithTenantId
    {
        protected Entity(Guid id, Guid tenantId)
        {
            if(id == default(Guid))
                throw new ArgumentException("id");
            if (tenantId == default(Guid))
                throw new ArgumentException("tenantId");

            Id = id;
            TenantId = tenantId;
        }

        public Guid Id { get; protected set; }

        public Guid TenantId { get; protected set; }
    }
}
