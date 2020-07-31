using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.Reusable.Combo
{
    public class ComboViewModel
    {
        public int Value { get; set; }
        public string Label { get; set; }
        public virtual ICollection<ComboViewModel> Children { get; set; }
    }
}
