using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Data.Mapping.Product
{
    public class ProductMap : IEntityTypeConfiguration<Entities.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Entities.Product.Product> builder)
        {
            builder.ToTable("Product")
                .HasKey(c => c.Id);
        }
    }
}
