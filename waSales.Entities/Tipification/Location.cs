using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Configuration;

namespace waSales.Entities.Tipification
{
    public class Location
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
