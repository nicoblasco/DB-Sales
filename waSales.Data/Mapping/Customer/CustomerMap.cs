
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace waSales.Data.Mapping.Customer
{
    public class CustomerMap : IEntityTypeConfiguration<Entities.Customer.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer.Customer> builder)
        {
            builder.ToTable("Customer")
                .HasKey(c => c.Id);
        }
    }
}
