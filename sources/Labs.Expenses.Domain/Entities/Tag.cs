using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Entities
{
    public class Tag : Entity
    {
        protected Tag()
        {
        }

        public Tag(Guid id, Guid tenantId) 
            : base(id, tenantId)
        {
        }

        public string Name { get; set; }
    }
}