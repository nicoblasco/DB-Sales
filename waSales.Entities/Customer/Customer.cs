using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Tipification;

namespace waSales.Entities.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public int? DocumentTypeId { get; set; }
        public string Documento { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }       
        public int CompanyId { get; set; }
        public DateTime? DateInitial { get; set; }
        public bool Favorite { get; set; }
        public string Observation { get; set; }
        public string Phone { get; set; }
        public bool Enabled { get; set; }
        public string Logo { get; set; }
        public int? PriceListId { get; set; }

        public virtual City Cities { get; set; }
        public virtual DocumentType DocumentTypes { get; set; }

        public virtual PriceList  PriceLists { get; set; }

    }
}
