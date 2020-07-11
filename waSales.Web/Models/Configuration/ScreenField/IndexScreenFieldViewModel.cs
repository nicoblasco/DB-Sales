﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waSales.Entities.Configuration;

namespace waSales.Web.Models.Configuration.ScreenField
{
    public class IndexScreenFieldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Entity { get; set; }

        public int CompanyId { get; set; }



        public List< ConfigScreenField> ConfigScreenFields { get; set; }
    }
}
