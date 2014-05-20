using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class ModifyExpenseCommand : Command
    {
        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        public DateTimeOffset? PurchaseDate { get; set; }

        [Required]
        public string Merchant { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        public decimal? Vat { get; set; }
    }
}