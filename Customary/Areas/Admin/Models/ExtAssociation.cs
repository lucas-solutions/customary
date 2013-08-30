using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    public class ExtAssociation
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string PrimaryKey { get; set; }

        public string ForeignKey { get; set; }
    }
}