using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType")
            .HasKey(c => c.Id);
        }
    }
}
