using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.Provider
{
    public class Provider
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int DocumentTypeId { get; set; }
        public string Documento { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int CompanyId { get; set; }
        public DateTime? DateInitial { get; set; }
        public bool Favorite { get; set; }
        public string Observation { get; set; }
        public string Phone { get; set; }
        public bool Enabled { get; set; }
    }
}
