using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class ListViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public List List { get; set; }
    }
}