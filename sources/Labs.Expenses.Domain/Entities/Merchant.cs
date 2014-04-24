using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Entities
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