using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.System;

namespace waSales.Data.Mapping.System
{
    public class LogErrorMap : IEntityTypeConfiguration<LogError>
    {
        public void Configure(EntityTypeBuilder<LogError> builder)
        {
            builder.ToTable("LogError")
            .HasKey(c => c.Id);

        }
    }
}
