using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class SystemActionMap : IEntityTypeConfiguration<SystemAction>
    {
        public void Configure(EntityTypeBuilder<SystemAction> builder)
        {
            builder.ToTable("SystemAction")
            .HasKey(c => c.Id);

        }
    }
}
