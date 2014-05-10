using System;
using System.ComponentModel.DataAnnotations;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Commands
{
    public class AddExpenseCommand : Command
    {
        public AddExpenseCommand(Guid tenantId, Guid commandId)
            : base(tenantId, commandId)
        {
        }

        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        public Guid PolicyId { get; set; }

        public DateTimeOffset? PurchaseDate { get; set; }

        public string Merchant { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Vat { get; set; }
    }

    public class AddExpenseResult : Result
    {
        public AddExpenseResult(Guid tenantId, Guid commandId) 
            : base(tenantId, commandId)
        {
        }
    }
}