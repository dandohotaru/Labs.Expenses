using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Mappings
{
    public class ExpenseMap : EntityTypeConfiguration<Expense>
    {
        public ExpenseMap()
        {
            // Table & Column Mappings
            ToTable("Expense", "expenses");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.TenantId).HasColumnName("TenantId").IsRequired();
            Property(t => t.Version).HasColumnName("Version").IsConcurrencyToken();
            Property(t => t.PolicyId).HasColumnName("PolicyId");
            Property(t => t.MerchantId).HasColumnName("MerchantId");
            Property(t => t.Date).HasColumnName("Date");
            Property(t => t.Amount).HasColumnName("Amount");
            Property(t => t.Vat).HasColumnName("Vat");

            // Relationships
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