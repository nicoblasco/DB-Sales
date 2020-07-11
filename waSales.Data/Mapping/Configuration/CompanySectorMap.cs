using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Configuration;

namespace waSales.Data.Mapping.Configuration
{
    public class CompanySectorMap : IEntityTypeConfiguration<CompanySector>
    {
        public void Configure(EntityTypeBuilder<CompanySector> builder)
        {
            builder.ToTable("CompanySector")
            .HasKey(c => c.Id);
        }
    }
}
