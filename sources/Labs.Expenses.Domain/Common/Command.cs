﻿using System;
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

        protected Command(Guid commandId)
            : this(SystemTenant.Current().Id, commandId)
        {
            // ToDo: Remove constructor once the system supports multiple tenants [DanD].
        }

        [Required]
        public Guid CommandId { get; protected set; }

        [Required]
        public Guid TenantId { get; protected set; }

        [Required]
        public DateTimeOffset Timestamp { get; protected set; }
    }
}