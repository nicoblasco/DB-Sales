using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Product
{
    public class ProductPriceListsViewModel
    {
        public int Id { get; set; }
        public int PriceList { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public bool IsRemoved { get; set; }
    }
}
