using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    using Custom.Models;

    public class ProxyViewModel : ViewModel
    {
        public string Type { get; set; }

        public string Url { get; set; }
    }
}