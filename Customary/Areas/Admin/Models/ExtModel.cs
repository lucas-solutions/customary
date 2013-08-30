using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    public class ExtModel
    {
        ProxyViewModel _proxy;

        public string Name { get; set; }

        public ProxyViewModel Proxy { get { return _proxy ?? (_proxy = new ProxyViewModel()); } set { _proxy = value; } }

        

        public List<AssociationViewModel> Associations { get; set; }
    }
}