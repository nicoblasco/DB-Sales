using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Tree
{
    public class TreeViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public virtual ICollection<TreeViewModel> Children { get; set; }
    }
}
