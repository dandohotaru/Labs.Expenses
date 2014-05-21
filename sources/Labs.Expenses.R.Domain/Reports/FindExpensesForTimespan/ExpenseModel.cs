using System;
using System.Collections.Generic;

namespace Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan
{
    public class ExpenseModel
    {
        public Guid ExpenseId { get; set; }

        public Guid PolicyId { get; set; }

        public string PolicyName { get; set; }

        public List<string> Tags { get; set; }

        public Guid MerchantId { get; set; }

        public string MerchantName { get; set; }

        public DateTimeOffset PurchaseDate { get; set; }

        public decimal Amount { get; set; }

        public decimal? Vat { get; set; }
    }
}