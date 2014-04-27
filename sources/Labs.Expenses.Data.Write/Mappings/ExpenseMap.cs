using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Mappings
{
    public class ExpenseMap : EntityTypeConfiguration<Expense>
    {
        public ExpenseMap()
        {
            ToTable("Expense", "expenses");

            HasRequired(p => p.Merchant)
                .WithMany()
                .HasForeignKey(p => p.MerchantId);
            HasMany(p => p.Tags)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ExpenseId");
                    m.MapRightKey("TagId");
                    m.ToTable("ExpenseTag");
                });
        }
    }
}