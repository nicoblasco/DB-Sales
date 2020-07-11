using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Security;

namespace waSales.Data.Mapping.Security
{
    public class SecurityRoleScreenMap : IEntityTypeConfiguration<SecurityRoleScreen>
    {
        public void Configure(EntityTypeBuilder<SecurityRoleScreen> builder)
        {
            builder.ToTable("SecurityRoleScreen")
                .HasKey(c => c.Id);
        }
    }
}
