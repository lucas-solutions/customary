using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PropertyAttribute : DefinitionAttribute
    {
        public object Default
        {
            get;
            set;
        }

        public bool Ignore
        {
            get;
            set;
        }
    }
}
