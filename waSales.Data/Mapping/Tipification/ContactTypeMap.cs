using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class ContactTypeMap : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.ToTable("ContactType")
            .HasKey(c => c.Id);
        }
    }
}
