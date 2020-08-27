using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Data.Mapping.Product
{
    public class ProductPriceListsMap : IEntityTypeConfiguration<Entities.Product.ProductPriceLists>
    {
        public void Configure(EntityTypeBuilder<Entities.Product.ProductPriceLists> builder)
        {
            builder.ToTable("ProductPriceLists")
                .HasKey(c => c.Id);
        }
    }
}