using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class SystemRoleScreenMap : IEntityTypeConfiguration<SystemRoleScreen>
    {
        public void Configure(EntityTypeBuilder<SystemRoleScreen> builder)
        {
            builder.ToTable("SystemRoleScreen")
            .HasKey(c => c.Id);

        }
    }
}
