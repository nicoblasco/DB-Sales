using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waSales.Web.Models.Configuration.ScreenField;
using waSales.Web.Models.Security.Action;

namespace waSales.Web.Models.Configuration.Screen
{
    public class ConfigScreenViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int Orden { get; set; }

        public string Icon { get; set; }

        public int CompanyId { get; set; }
        public int SystemScreenId { get; set; }

        public bool IsDefault { get; set; }

        public string Path { get; set; }
        public int? ParentId { get; set; }
        public bool IsNew { get; set; }
        public bool IsRemoved { get; set; }

        public List<ConfigScreenFieldViewModel> ConfigScreenFields { get; set; }
        public List<SecurityActionViewModel> SecurityActions { get; set; }
    }
}
