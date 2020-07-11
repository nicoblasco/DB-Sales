using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod")
            .HasKey(c => c.Id);
        }
    }
}
