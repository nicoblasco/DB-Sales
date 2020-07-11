using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Dependent
{
    public class IndexDependentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public int ParentId { get; set; }

        public string Parent { get; set; }
    }
}
