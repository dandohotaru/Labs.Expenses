using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class AddMerchantCommand : Command
    {
        public AddMerchantCommand(Guid rootId, Guid commandId)
            : base(rootId, commandId)
        {
        }

        [Required]
        public Guid MerchantId { get; set; }

        public string Name { get; set; }
    }
}