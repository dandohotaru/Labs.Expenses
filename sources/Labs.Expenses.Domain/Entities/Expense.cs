using System;
using System.Collections.Generic;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Entities
{
    public class Expense : Entity
    {
        protected Expense()
        {
        }

        public Expense(Guid id, Guid tenantId)
            : base(id, tenantId)
        {
        }

        public Guid PolicyId { get; set; }

        public decimal Amount { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Guid MerchantId { get; set; }

        public Merchant Merchant { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}