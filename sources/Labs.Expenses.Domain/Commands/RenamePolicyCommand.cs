using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Commands
{
    public class RenamePolicyCommand : Command
    {
        public RenamePolicyCommand(Guid commandId, Guid tenantId)
            : base(commandId, tenantId)
        {
        }

        [Required]
        public Guid PolicyId { get; set; }

        public string Name { get; set; }
    }
}