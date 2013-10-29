using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public static class PrototypeExtensions
    {
        public static TypeDefinition Save(this TypeDefinition type)
        {
            var session = Global.Metadata.Session;
            session.Store(type);
            return type;
        }
    }
}