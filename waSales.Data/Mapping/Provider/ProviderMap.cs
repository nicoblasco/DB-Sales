
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Provider;

namespace waSales.Data.Mapping.Provider
{
    public class ProviderMap : IEntityTypeConfiguration<Entities.Provider.Provider>
    {
        public void Configure(EntityTypeBuilder<Entities.Provider.Provider> builder)
        {
            builder.ToTable("Provider")
                .HasKey(c => c.Id);
        }
    }
}
