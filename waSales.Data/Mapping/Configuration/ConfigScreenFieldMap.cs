using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Configuration;

namespace waSales.Data.Mapping.Configuration
{
    public class ConfigScreenFieldMap : IEntityTypeConfiguration<ConfigScreenField>
    {
        public void Configure(EntityTypeBuilder<ConfigScreenField> builder)
        {
            builder.ToTable("ConfigScreenField")
            .HasKey(c => c.Id);
        }
    }
}
