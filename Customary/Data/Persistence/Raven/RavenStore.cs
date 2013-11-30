using System;
using System.Configuration;

namespace Custom.Data.Persistence.Raven
{
    using global::Raven.Abstractions.Replication;
    using global::Raven.Client;
    using global::Raven.Client.Document;
    using global::Raven.Client.Embedded;
    using global::Raven.Client.Indexes;
    using global::Raven.Json.Linq;

    public class RavenStore
    {
        private const string RavenReplicationDestinations = "Raven/Replication/Destinations";

        private static readonly object _lock = new object();

        [ThreadStatic]
        private static IDocumentSession _session;

        private static IDocumentStore _store;

        private readonly RavenStoreInfo _info;

        protected RavenStore(RavenStoreInfo info)
        {
            _info = info;
        }

        public IDocumentSession Session
        {
            get { return Store.OpenSession(); }
        }

        public IDocumentStore Store
        {
            get
            {
                var store = _store;

                // return without locking if already exist
                if (store != null)
                    return store;

                // lock and check again
                lock (_lock)
                {
                    // create new instance if doesn't exist
                    store = _store ?? (_store = CreateDocumentStore(_info));

                    InitializeDocumentStore(store);

                    // save store instance
                    _store = store;
                }

                return store;
            }
        }

        protected virtual void InitializeDocumentStore(IDocumentStore store)
        {
            //store.Conventions.IdentityPartsSeparator = "/";
            store.Conventions.SaveEnumsAsIntegers = false;

            store.Initialize();

            new RavenDocumentsByEntityName().Execute(store);
        }

        public void SaveChanges()
        {
            var session = _session;

            if (session != null)
            {
                _session = null;

                session.SaveChanges();
            }
        }

        /// <summary>
        /// When running in embedded mode, you can't replicate to that instance (since it has no HTTP endpoint, 
        /// unless you use Embedded+HTTP mode but you can replicate from that instance.
        /// See http://ravendb.net/docs/2.0/server/scaling-out/replication
        /// </summary>
        /// <param name="info"></param>
        private void InitializeReplicationDestinations(RavenStoreInfo info)
        {
            var replication = info.Replication;

            if (replication != null)
            {
                Session.Store(info.Replication);
            }
        }

        protected IDocumentStore CreateDocumentStore(RavenStoreInfo info)
        {
            IDocumentStore store;

            var settings = ConfigurationManager.ConnectionStrings[info.Name];

            if (info.Embeddable)
            {
                var embeddableStore = new EmbeddableDocumentStore
                {
                    ApiKey = info.ApiKey + '/' + info.Secret,
                    DataDirectory = "/App_Data/" + info.Name
                };

                store = embeddableStore;
            }
            else
            {
                var documentStore = new DocumentStore
                {
                    ApiKey = info.ApiKey + '/' + info.Secret
                };

                if (info.Url != null)
                {
                    documentStore.Url = info.Url;
                }
                else if (settings != null)
                {
                    documentStore.ConnectionStringName = _info.Name;
                }
                else
                {
                    // ?
                }

                store = documentStore;
            }

            return store;
        }
    }
}