using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Configuration;

namespace waSales.Data.Mapping.Configuration
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company")
            .HasKey(c => c.Id);
        }
    }
}
