using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class SystemRoleMap : IEntityTypeConfiguration<SystemRole>
    {
        public void Configure(EntityTypeBuilder<SystemRole> builder)
        {
            builder.ToTable("SystemRole")
            .HasKey(c => c.Id);

        }
    }
}
