using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Cascade
{
    public class UpdateCascadeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
    }
}
