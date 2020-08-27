using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Data.Mapping.Product
{
    public class ProductProvidersMap : IEntityTypeConfiguration<Entities.Product.ProductProviders>
    {
        public void Configure(EntityTypeBuilder<Entities.Product.ProductProviders> builder)
        {
            builder.ToTable("ProductProviders")
                .HasKey(c => c.Id);
        }  

    }
}
