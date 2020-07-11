using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class ExchangeCurrencyMap : IEntityTypeConfiguration<ExchangeCurrency>
    {
        public void Configure(EntityTypeBuilder<ExchangeCurrency> builder)
        {
            builder.ToTable("ExchangeCurrency")
            .HasKey(c => c.Id);
        }
    }
}
