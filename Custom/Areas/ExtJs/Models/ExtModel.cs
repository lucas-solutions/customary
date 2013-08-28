using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.ExtJs.Models
{
    public class ExtModel
    {
        ExtProxy _proxy;

        public string Name { get; set; }

        public ExtProxy Proxy { get { return _proxy ?? (_proxy = new ExtProxy()); } set { _proxy = value; } }

        public List<ExtField> Fields { get; set; }

        public List<ExtAssociation> Associations { get; set; }
    }
}