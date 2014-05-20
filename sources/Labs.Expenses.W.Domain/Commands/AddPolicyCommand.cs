using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class AddPolicyCommand : Command
    {
        public AddPolicyCommand(Guid rootId, Guid commandId)
            : base(rootId, commandId)
        {
        }

        [Required]
        public Guid PolicyId { get; set; }

        public string Name { get; set; }
    }
}