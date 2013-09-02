using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class ColumnViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public Grid Model { get; set; }

        public Column Property { get; set; }
    }
}