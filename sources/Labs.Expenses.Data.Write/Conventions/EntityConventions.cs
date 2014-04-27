using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Labs.Expenses.W.Data.Conventions
{
    public class EntityConventions : Convention
    {
        public EntityConventions()
        {
            Properties<Guid>()
                .Where(p => p.Name == "Id")
                .Configure(p =>
                {
                    p.IsKey();
                    p.IsRequired();
                    p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                });

            Properties<Guid>()
                .Where(p => p.Name == "TenantId")
                .Configure(p => p.IsRequired());

            Properties<byte[]>()
                .Where(p => p.Name == "Version")
                .Configure(p => p.IsConcurrencyToken());

            Properties()
                .Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name));
        }
    }
}