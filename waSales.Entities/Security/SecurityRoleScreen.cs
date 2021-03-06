﻿using System;
using System.Collections.Generic;
using System.Text;
using waSales.Entities.Configuration;

namespace waSales.Entities.Security
{
    public class SecurityRoleScreen
    {
        public int Id { get; set; }
        public int SecurityRoleId { get; set; }
        public int ConfigScreenId { get; set; }

        public virtual SecurityRole SecurityRole { get; set; }
        public virtual ConfigScreen ConfigScreen { get; set; }
    }
}
