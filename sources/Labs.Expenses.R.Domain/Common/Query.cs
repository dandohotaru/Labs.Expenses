using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.R.Domain.Common
{
    public abstract class Query : IQuery
    {
        [Required]
        public Guid QueryId { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}