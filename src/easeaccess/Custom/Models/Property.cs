using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Raven.Json.Linq;

    public class Property : Element
    {
        public Property(RavenJObject o, Template t)
            : base(o, t.Properties)
        {
        }
    }
}