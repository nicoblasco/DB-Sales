using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Tipification;

namespace waSales.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DateInitial { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? LocationId { get; set; }
        public decimal? Stock { get; set; }

        public decimal? StockMin { get; set; }
        public decimal? Cost { get; set; }

        public decimal? Gain { get; set; }

        public decimal? Price { get; set; }

        public DateTime? DateEnd { get; set; }
        public int ExchangeCurrencyId { get; set; }
        public int? Discount { get; set; }
        public int CompanyId { get; set; }
        public bool? InStock { get; set; }
        public bool? Awaiting { get; set; }
        public bool? OutOfStock { get; set; }
        public string Logo { get; set; }
        public bool? CheckStock { get; set; }
        public bool Enabled{ get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Location Location { get; set; }
        public virtual ExchangeCurrency ExchangeCurrency { get; set; }

        public ICollection<Entities.Product.ProductProviders> ProductProviders { get; set; }
        public ICollection<Entities.Product.ProductPriceLists> ProductPriceLists { get; set; }


    }
}
