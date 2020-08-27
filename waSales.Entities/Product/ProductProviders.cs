using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.Product
{
    public class ProductProviders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Entities.Provider.Provider Provider { get; set; }
    }
}
