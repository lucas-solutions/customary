using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public class EntityStore
    {
        /// <summary>
        /// Name of the document or table.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Store type: document, table, sproc, service, REST, etc
        /// </summary>
        public EntityStoreTypes Type { get; set; }

        /// <summary>
        /// Create or add new entries.
        /// </summary>
        public string Create { get; set; }

        /// <summary>
        /// Read, retrieve, search, or view existing entries
        /// </summary>
        public string Read { get; set; }

        /// <summary>
        /// Update or edit existing entries
        /// </summary>
        public string Update { get; set; }

        /// <summary>
        /// Delete/deactivate existing entries
        /// </summary>
        public string Destroy { get; set; }
    }
}