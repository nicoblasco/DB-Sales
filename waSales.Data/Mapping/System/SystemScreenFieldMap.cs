using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;
namespace waSales.Data.Mapping.System
{
    public class SystemScreenFieldMap : IEntityTypeConfiguration<SystemScreenField>
    {
        public void Configure(EntityTypeBuilder<SystemScreenField> builder)
        {
            builder.ToTable("SystemScreenField")
            .HasKey(c => c.Id);

        }
    }
}
