using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Security;

namespace waSales.Data.Mapping.Security
{
    public class SecurityRoleActionMap : IEntityTypeConfiguration<SecurityRoleAction>
    {
        public void Configure(EntityTypeBuilder<SecurityRoleAction> builder)
        {
            builder.ToTable("SecurityRoleAction")
                .HasKey(c => c.Id);
        }
    }
}
