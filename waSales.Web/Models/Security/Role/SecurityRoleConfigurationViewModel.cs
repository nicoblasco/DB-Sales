using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waSales.Web.Models.Security.RoleScreen;

namespace waSales.Web.Models.Security.Role
{
    public class SecurityRoleConfigurationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SecurityRoleScreenConfViewModel> Screens { get; set; }
    }
}
