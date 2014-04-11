﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Labs.Expenses.Domain.Entities;

namespace Labs.Expenses.Data.Write.Mappings
{
    public class PolicyMap : EntityTypeConfiguration<Policy>
    {
        public PolicyMap()
        {
            // Table & Column Mappings
            ToTable("Policy", "expenses");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.TenantId).HasColumnName("TenantId").IsRequired();
            Property(t => t.Version).HasColumnName("Version").IsConcurrencyToken();
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}