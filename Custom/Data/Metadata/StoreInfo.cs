﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class StoreInfo
    {
        /// <summary>
        /// Name of SQL Server catalog or RavenDB store
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Server address
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Store provider
        /// </summary>
        public StoreProviders Provider { get; set; }

        /// <summary>
        /// Doument, Record, Procedure, Restful, Ajax
        /// </summary>
        public StoreTypes Type { get; set; }
    }
}