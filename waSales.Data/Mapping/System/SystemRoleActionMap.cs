using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class SystemRoleActionMap : IEntityTypeConfiguration<SystemRoleAction>
    {
        public void Configure(EntityTypeBuilder<SystemRoleAction> builder)
        {
            builder.ToTable("SystemRoleAction")
            .HasKey(c => c.Id);

        }
    }
}
