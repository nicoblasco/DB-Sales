using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;


namespace waSales.Data.Mapping.Tipification
{
    public class SalesStateMap : IEntityTypeConfiguration<SalesState>
    {
        public void Configure(EntityTypeBuilder<SalesState> builder)
        {
            builder.ToTable("SalesState")
            .HasKey(c => c.Id);
        }
    }
}
