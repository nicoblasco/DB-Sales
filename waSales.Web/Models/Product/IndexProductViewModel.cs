﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Product
{
    public class IndexProductViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string DateInitial { get; set; }

        public string Name { get; set; }
        public string NameShort { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int? BrandId { get; set; }
        public string Brand { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public decimal? Stock { get; set; }

        public decimal? StockMin { get; set; }
        public decimal? Cost { get; set; }

        public decimal? Gain { get; set; }

        public decimal? Price { get; set; }

        public int ExchangeCurrencyId { get; set; }
        public string ExchangeCurrency { get; set; }
        public decimal? Discount { get; set; }
        public bool? InStock { get; set; }
        public bool? Awaiting { get; set; }
        public bool? OutOfStock { get; set; }
        public string Logo { get; set; }
        public string LogoName { get; set; }
        public bool? CheckStock { get; set; }
        public string Status { get; set; }


    }
}
