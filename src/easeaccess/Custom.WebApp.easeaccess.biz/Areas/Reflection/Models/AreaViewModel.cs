using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class AreaViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public Area Area { get; set; }
    }
}