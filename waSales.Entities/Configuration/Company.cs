using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Security;

namespace waSales.Entities.Configuration
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ContactName { get; set; }
        public string ContactLastName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Enabled { get; set; }
        public DateTime? InitialDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Schedule { get; set; }
        public string Logo { get; set; }
        public string Comment { get; set; }

        public ICollection<CompanySector> CompanySectors { get; set; }

        public ICollection<SecurityUser> Usuarios { get; set; }
        public ICollection<ConfigScreen> ConfigScreen { get; set; }
        public ICollection<SecurityRole> SecurityRoles { get; set; }
    }
}
