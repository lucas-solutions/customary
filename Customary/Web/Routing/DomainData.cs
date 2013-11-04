using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Web.Routing
{
    /// <summary>
    /// Used for DomainRoute
    /// </summary>
    public class DomainData
    {
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public string Fragment { get; set; }
    }
}