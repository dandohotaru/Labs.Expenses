using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.W.Domain.Common
{
    public interface ICommand : IMessage
    {
        [Required]
        Guid CommandId { get; set; }

        [Required]
        Guid TenantId { get; set; }

        [Required]
        DateTimeOffset Timestamp { get; set; }
    }
}