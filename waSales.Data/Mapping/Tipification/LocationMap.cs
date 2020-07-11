using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;


namespace waSales.Data.Mapping.Tipification
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location")
            .HasKey(c => c.Id);
        }
    }
}
