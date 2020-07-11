using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.Tipification
{
    public class City
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
