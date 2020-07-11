using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Cascade
{
    public class CreateCascadeViewModel
    {
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int CompanyId { get; set; }
    }
}
