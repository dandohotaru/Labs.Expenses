using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.Domain.Values;

namespace Labs.Expenses.Domain.Common
{
    public abstract class Command : ICommand
    {
        private Command()
        {
            Timestamp = SystemTime.Now();
        }

        protected Command(Guid commandId, Guid tenantId)
            : this()
        {
            if (commandId == default(Guid))
                throw new ArgumentException("commandId");
            if (tenantId == default(Guid))
                throw new ArgumentException("tenantId");

            CommandId = commandId;
            TenantId = tenantId;
        }

        [Required]
        public Guid CommandId { get; protected set; }

        [Required]
        public Guid TenantId { get; protected set; }

        [Required]
        public DateTimeOffset Timestamp { get; protected set; }
    }
}