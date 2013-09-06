using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Repositories;

    public class ComplexDescriptor : TypeDescriptor
    {
        /// <summary>
        /// Name of complex type it inherits or extends. Entities can extend complex or entity types.
        /// </summary>
        public string Extend { get; set; }
    }
}