using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Custom.Site.Presentation.Sencha.Ext
{
    public static class TypeExtensions
    {
        const string Ext = "Ext";

        public static string ClassName(this System.Type type)
        {
            var ext = type.GetCustomAttribute<ExtAttribute>(false);

            if (ext != null && !string.IsNullOrEmpty(ext.Name))
                return ext.Name;

            return ExtNamespace(type.Namespace) + '.' + type.Name;
        }

        private static string ExtNamespace(string ns, string preffix = null)
        {
            var extIndex = ns.IndexOf(Ext);

            switch (extIndex)
            {
                case -1:
                    return ns;

                case 0:
                    return Ext + ns.Substring(Ext.Length).ToLower();

                default:
                    return Ext + ns.Substring(extIndex + Ext.Length).ToLower();
            }
        }
    }
}