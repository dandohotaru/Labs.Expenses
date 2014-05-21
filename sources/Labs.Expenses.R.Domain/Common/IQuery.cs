using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.R.Domain.Common
{
    public interface IQuery : IMessage
    {
        [Required]
        Guid QueryId { get; set; }

        [Required]
        Guid TenantId { get; set; }

        [Required]
        DateTimeOffset Timestamp { get; set; }
    }
}