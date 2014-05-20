using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class RemoveExpenseCommand : Command
    {
        [Required]
        public Guid ExpenseId { get; set; }
    }
}