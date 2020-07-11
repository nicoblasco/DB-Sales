using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class SalesUnitMap : IEntityTypeConfiguration<SalesUnit>
    {
        public void Configure(EntityTypeBuilder<SalesUnit> builder)
        {
            builder.ToTable("SalesUnit")
            .HasKey(c => c.Id);
        }
    }
}
