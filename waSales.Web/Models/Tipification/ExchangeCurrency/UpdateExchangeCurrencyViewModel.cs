using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Tipification.ExchangeCurrency
{
    public class UpdateExchangeCurrencyViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Quote { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
