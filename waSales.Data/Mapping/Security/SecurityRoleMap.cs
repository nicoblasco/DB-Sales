using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Security;

namespace waSales.Data.Mapping.Security
{
    public class SecurityRoleMap : IEntityTypeConfiguration<SecurityRole>
    {
        public void Configure(EntityTypeBuilder<SecurityRole> builder)
        {
            builder.ToTable("SecurityRole")
                .HasKey(c => c.Id);
        }
    }
}
