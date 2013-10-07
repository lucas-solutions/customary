using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public abstract class TypeDescriptor : Descriptor
    {
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Name of object type it inherits or extends. Entities can extend object or entity types.
        /// </summary>
        public string Extend
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