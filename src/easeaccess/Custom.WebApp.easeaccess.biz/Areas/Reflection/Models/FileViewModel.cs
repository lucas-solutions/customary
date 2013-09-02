using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class FileViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public File File { get; set; }
    }
}