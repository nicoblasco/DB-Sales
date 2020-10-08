using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class DeliveryTurnMap : IEntityTypeConfiguration<DeliveryTurn>
    {
        public void Configure(EntityTypeBuilder<DeliveryTurn> builder)
        {
            builder.ToTable("DeliveryTurn")
            .HasKey(c => c.Id);
        }
    }
}
