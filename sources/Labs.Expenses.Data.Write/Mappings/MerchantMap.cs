using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Mappings
{
    public class MerchantMap : EntityTypeConfiguration<Merchant>
    {
        public MerchantMap()
        {
            ToTable("Merchant", "expenses");
        }
    }
}