using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    /// <summary>
    /// Used in PropertyDescriptor. If defined, it is used in order to read/write the property to the storage.
    /// </summary>
    public class PropertyMapping
    {
        /// <summary>
        /// Name of an static converter used to convert back and forth
        /// </summary>
        public string Convert { get; set; }

        /// <summary>
        /// Name of the property at the storage
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the property at the storage
        /// </summary>
        public string Type { get; set; }
    }
}