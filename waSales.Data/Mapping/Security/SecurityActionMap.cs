using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Security;

namespace waSales.Data.Mapping.Security
{
    public class SecurityActionMap : IEntityTypeConfiguration<SecurityAction>
    {
        public void Configure(EntityTypeBuilder<SecurityAction> builder)
        {
            builder.ToTable("SecurityAction")
                .HasKey(c => c.Id);
        }
    }
}
