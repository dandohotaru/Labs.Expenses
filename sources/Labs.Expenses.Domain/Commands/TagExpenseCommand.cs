using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class TagExpenseCommand : Command
    {
        public TagExpenseCommand(Guid commandId, Guid tenantId)
            : base(commandId, tenantId)
        {
        }

        [Required]
        public Guid ExpenseId { get; set; }

        public List<string> Tags { get; set; }
    }
}