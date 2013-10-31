using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public class Repository
    {
        /// <summary>
        /// Optional catalog. It would take it or the missing fields from the parent area.
        /// </summary>
        public StoreInfo Catalog { get; set; }

        /// <summary>
        /// Name of the document or table.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create or add new entries.
        /// </summary>
        public string Insert { get; set; }

        /// <summary>
        /// Read, retrieve, search, or view existing entries
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// Update or edit existing entries
        /// </summary>
        public string Update { get; set; }

        /// <summary>
        /// Delete/deactivate existing entries
        /// </summary>
        public string Delete { get; set; }
    }
}