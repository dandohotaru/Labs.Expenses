using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class RemoveExpenseCommand : Command
    {
        public RemoveExpenseCommand(Guid commandId, Guid tenantId)
            : base(tenantId, commandId)
        {
        }

        [Required]
        public Guid ExpenseId { get; set; }
    }
}