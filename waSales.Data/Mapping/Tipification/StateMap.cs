using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using waSales.Entities.Tipification;

namespace waSales.Data.Mapping.Tipification
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State")
            .HasKey(c => c.Id);
        }
    }
}
