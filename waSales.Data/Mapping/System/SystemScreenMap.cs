using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class SystemScreenMap : IEntityTypeConfiguration<SystemScreen>
    {
        public void Configure(EntityTypeBuilder<SystemScreen> builder)
        {
            builder.ToTable("SystemScreen")
            .HasKey(c => c.Id);

        }
    }
}
