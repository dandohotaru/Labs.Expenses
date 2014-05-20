using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Values;

namespace Labs.Expenses.W.Domain.Commands
{
    public class AddExpenseCommand : Command
    {
        public AddExpenseCommand(Guid rootId, Guid commandId)
            : base(rootId, commandId)
        {
            PolicyId = SystemPolicy.Current().Id;
        }

        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        public Guid PolicyId { get; protected set; }

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