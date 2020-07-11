﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waSales.Web.Models.System.Screen
{
    public class CreateSystemScreenViewModel
    {
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public bool IsDefault { get; set; }


        public int? ParentId { get; set; }
        public int Orden { get; set; }
        public string Entity { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
    }
}
