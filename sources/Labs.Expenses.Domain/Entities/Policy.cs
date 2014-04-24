using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Entities
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