using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class RemoveExpenseCommand : Command
    {
        public RemoveExpenseCommand(Guid rootId, Guid commandId)
            : base(rootId, commandId)
        {
        }

        [Required]
        public Guid ExpenseId { get; set; }
    }
}