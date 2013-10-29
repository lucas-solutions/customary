using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public static class PropertyExtensions
    {
        public static PropertyDefinition Save(this PropertyDefinition property)
        {
            var session = Global.Metadata.Session;
            session.Store(property);
            return property;
        }
    }
}