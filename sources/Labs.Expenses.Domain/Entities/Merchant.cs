using System;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Entities
{
    public class Merchant : Entity
    {
        protected Merchant()
        {
        }

        public Merchant(Guid id, Guid tenantId)
            : base(id, tenantId)
        {
        }

        public string Name { get; set; }
    }
}