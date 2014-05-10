using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Common
{
    public abstract class Command : ICommand
    {
        private Command()
        {
            Timestamp = SystemTime.Now();
        }

        protected Command(Guid tenantId, Guid commandId)
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