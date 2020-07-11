using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Common
{
    public class CommonViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public int CompanyId { get; set; }
    }
}
