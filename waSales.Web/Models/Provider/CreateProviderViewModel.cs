using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Provider
{
    public class CreateProviderViewModel
    {
        public string RazonSocial { get; set; }
        public int? DocumentTypeId { get; set; }
        public string Documento { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int CompanyId { get; set; }
        public bool Favorite { get; set; }
        public string Observation { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string LogoName { get; set; }

    }
}
