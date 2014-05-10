using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Mappings
{
    public class PolicyMap : EntityTypeConfiguration<Policy>
    {
        public PolicyMap()
        {
            ToTable("Policy", "expenses");
        }
    }
}