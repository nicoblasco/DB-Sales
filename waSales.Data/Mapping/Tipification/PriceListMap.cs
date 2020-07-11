using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class PriceListMap : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.ToTable("PriceList")
            .HasKey(c => c.Id);
        }
    }
}
