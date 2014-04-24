using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class ModifyExpenseCommand : Command
    {
        public ModifyExpenseCommand(Guid commandId, Guid tenantId)
            : base(commandId, tenantId)
        {
        }

        [Required]
        public Guid ExpenseId { get; set; }
        
        public DateTimeOffset? PurchaseDate { get; set; }

        public string Merchant { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Vat { get; set; }
    }
}