using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Raven
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Abstractions.Replication;

    public class RavenStoreInfo
    {
        public string ApiKey
        {
            get;
            set;
        }

        public List<ApiKeyDefinition> ApiKeys
        {
            get;
            set;
        }

       public bool Embeddable
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ReplicationDocument Replication
        {
            get;
            set;
        }

        public string Secret
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}