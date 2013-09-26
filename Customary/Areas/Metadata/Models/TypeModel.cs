using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    public class TypeModel
    {
        public Guid ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }
    }
}