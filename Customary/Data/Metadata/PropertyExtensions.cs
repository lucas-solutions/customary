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
            using (var session = Global.Metadata.Store.OpenSession())
            {
                session.Store(property);
            }
            return property;
        }
    }
}