using System;
using System.Collections.Generic;
using System.Text;

namespace waSales.Entities.System
{
    public class LogError
    {
        public Int64 Id { get; set; }
        public int CompanyId { get; set; }
        public int SecurityUserId { get; set; }
        public string Path { get; set; }
        public string Error { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
