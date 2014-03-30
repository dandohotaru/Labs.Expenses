using System;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Entities
{
    public class Policy : Entity
    {
        protected Policy()
        {
        }

        public Policy(Guid id, Guid tenantId) 
            : base(id, tenantId)
        {
        }

        public string Name { get; set; }
    }
}