using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waSales.Web.Models.Security.Role;

namespace waSales.Web.Models.Security.User
{
    public class UserConfigurationViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int SecurityRoleId { get; set; }
        public virtual SecurityRoleConfigurationViewModel Role { get; set; }



    }
}
