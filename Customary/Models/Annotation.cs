using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Custom.Diagnostics;

    public class Annotation
    {
        public LogCategories Category { get; set; }
        public string Message { get; set; }
    }
}