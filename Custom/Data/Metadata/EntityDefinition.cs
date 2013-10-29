using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public sealed class EntityDefinition : StructuralDefinition
    {
        /// <summary>
        /// Comma separated list of head (column in a grid) properties
        /// </summary>
        public string Head
        {
            get;
            set;
        }

        /// <summary>
        /// Document name, table name, REST (Representational state transfer) service URL.
        /// </summary>
        public EntityStore Store
        {
            get;
            set;
        }
    }
}