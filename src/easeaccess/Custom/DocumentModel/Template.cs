using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Raven.Json.Linq;

    public class Template : Document
    {
        private static readonly Template _protertyTemplate = new Template(;

        static Template()
        {
            
        }

        private readonly Collection<Property> _properties;
        
        public Template(RavenJObject o, Master m)
            : base(o, m)
        {
            _properties = new Collection<Property>("Properties", this);
        }

        public Collection<Property> Properties
        {
            get { return _properties; }
        }
    }
}