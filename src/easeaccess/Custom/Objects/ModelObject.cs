using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class ModelObject : ResourceObject
    {
        private List<PropertyObject> _properties;

        public List<PropertyObject> Properties
        {
            get { return _properties ?? (_properties = new List<PropertyObject>()); }
            set { _properties = value; }
        }

        public ProxyObject Proxy
        {
            get;
            set;
        }
    }
}