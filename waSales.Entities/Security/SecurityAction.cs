using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Configuration;
using waSales.Entities.System;

namespace waSales.Entities.Security
{
    public class SecurityAction
    {
        public int Id { get; set; }
        public int ConfigScreenId { get; set; }

        public int SystemActionId { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public virtual ConfigScreen ConfigScreen { get; set; }
        public virtual SystemAction SystemAction { get; set; }
    }
}
