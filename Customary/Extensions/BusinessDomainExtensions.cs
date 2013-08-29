using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    public static class BusinessDomainExtensions
    {
        public static BusinessDomain Store(this BusinessDomain domain)
        {
            var session = Global.Business.Session;
            session.Store(domain);
            return domain;
        }
    }
}