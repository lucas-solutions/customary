using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class AreaStore
    {
        /// <summary>
        /// Name of SQL Server catalog or RavenDB store
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// Server address
        /// </summary>
        public string Server { get; set; }
    }
}
