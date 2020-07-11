using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;
namespace waSales.Data.Mapping.Tipification
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country")
            .HasKey(c => c.Id);
        }
    }
}
