using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.Tipification
{
   public  class SubCategory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
