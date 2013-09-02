using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class FieldViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public Form Record { get; set; }

        public Field Field { get; set; }
    }
}