using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.Tipification
{
    public class State
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
