using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Mappings
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            ToTable("Tag", "expenses");
        }
    }
}