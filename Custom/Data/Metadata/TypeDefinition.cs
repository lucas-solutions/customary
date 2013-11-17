using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    /// <summary>
    /// Type definition
    /// </summary>
    public abstract class TypeDefinition : BaseDefinition
    {
        public Guid Id
        {
            get;
            set;
        }

        public string BaseType
        {
            get;
            set;
        }

        public string Runtime
        {
            get;
            set;
        }
    }
}