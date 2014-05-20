using System;
using System.ComponentModel.DataAnnotations;

namespace Labs.Expenses.W.Domain.Common
{
    public abstract class Command : ICommand
    {
        [Required]
        public Guid ContextId { get; set; }

        [Required]
        public Guid CommandId { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}