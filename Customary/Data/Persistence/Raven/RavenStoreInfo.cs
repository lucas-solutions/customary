using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Raven
{
    using global::Raven.Abstractions.Replication;
    using Custom.Data.Persistence.Raven.Replication;

    public class RavenStoreInfo
    {
        public string Name
        {
            get;
            set;
        }

        public bool Embeddable
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public ReplicationDocument Replication
        {
            get;
            set;
        }

        /// <summary>
        /// Replication Destinations. It's what telling the RavenDB instance where to replicate to.
        /// </summary>
        public List<Destination> Destinations
        {
            get;
            set;
        }
    }
}