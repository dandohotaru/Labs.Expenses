using System;
using System.Collections.Generic;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Entities
{
    public class Expense : Entity
    {
        public Guid PolicyId { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Guid MerchantId { get; set; }

        public Merchant Merchant { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Amount { get; set; }

        public decimal? Vat { get; set; }
    }
}