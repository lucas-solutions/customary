using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    public class FieldViewModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Default { get; set; }

        public string Convert { get; set; }
    }
}