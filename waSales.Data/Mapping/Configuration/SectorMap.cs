using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Configuration;

namespace waSales.Data.Mapping.Configuration
{
    public class SectorMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sector")
            .HasKey(c => c.Id);
        }
    }
}
