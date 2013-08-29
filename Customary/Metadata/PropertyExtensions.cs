using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public static class PropertyExtensions
    {
        public static PropertyDescriptor Save(this PropertyDescriptor property)
        {
            var session = Global.Metadata.Session;
            session.Store(property);
            return property;
        }
    }
}