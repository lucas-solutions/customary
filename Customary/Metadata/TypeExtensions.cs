using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public static class TypeExtensions
    {
        public static TypeDescriptor Save(this TypeDescriptor type)
        {
            var session = Global.Metadata.Session;
            session.Store(type);
            return type;
        }
    }
}