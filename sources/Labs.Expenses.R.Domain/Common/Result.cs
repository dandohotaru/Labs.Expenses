using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.R.Domain.Common
{
    public abstract class Result : IResult
    {
        [Required]
        public Guid QueryId { get; protected set; }

        [Required]
        public Guid TenantId { get; protected set; }

        [Required]
        public DateTimeOffset Timestamp { get; protected set; }
    }
}