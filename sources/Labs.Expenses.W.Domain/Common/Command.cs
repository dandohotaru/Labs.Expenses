using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Common
{
    public abstract class Command : ICommand
    {
        protected Command(Guid rootId, Guid commandId)
        {
            if (rootId == default(Guid))
                throw new ArgumentException("RootId");
            if (commandId == default(Guid))
                throw new ArgumentException("commandId");

            RootId = rootId;
            CommandId = commandId;
            TenantId = SystemTenant.Current().Id;
            Timestamp = SystemTime.Now();
        }

        [Required]
        public Guid RootId { get; private set; }

        [Required]
        public Guid CommandId { get; protected set; }

        [Required]
        public Guid TenantId { get; protected set; }

        [Required]
        public DateTimeOffset Timestamp { get; protected set; }
    }
}