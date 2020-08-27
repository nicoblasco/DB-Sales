using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Tipification;

namespace waSales.Entities.Product
{
    public class ProductPriceLists
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PriceListId { get; set; }
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual PriceList PriceList { get; set; }
    }
}
