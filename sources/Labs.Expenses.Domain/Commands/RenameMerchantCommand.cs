using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain.Commands
{
    public class RenameMerchantCommand : Command
    {
        public RenameMerchantCommand(Guid commandId, Guid tenantId)
            : base(commandId, tenantId)
        {
        }

        [Required]
        public Guid MerchantId { get; set; }

        public string Name { get; set; }
    }
}