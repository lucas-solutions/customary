using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class RavenDocumentCatalog : IRavenJObjectCatalog
    {
        [ThreadStatic]
        private static IDocumentSession _session;

        private readonly string _name;
        private readonly string _connectionString;
        private readonly object _lock = new object();

        private IDocumentStore _store;

        public RavenDocumentCatalog(string name)
        {
            _name = name;

            var settings = ConfigurationManager.ConnectionStrings[name];

            if (settings == null)
            {
                lock (_lock)
                {
                    settings = ConfigurationManager.ConnectionStrings[name];

                    if (settings == null)
                    {
                        settings = new ConnectionStringSettings { Name = name, ConnectionString = @"DataDir=~\App_Data\" + name };

                        ConfigurationManager.ConnectionStrings.Add(settings);
                    }
                }
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public string Name
        {
            get { return _name; }
        }

        public IDocumentSession Session
        {
            get { return _session ?? (_session = Store.OpenSession()); }
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
                    store = _store ?? (_store = CreateDocumentStore());

                    InitializeDocumentStore(store);

                    // save store instance
                    _store = store;
                }

                return store;
            }
        }

        protected virtual IDocumentStore CreateDocumentStore()
        {
            // ensure connection string

            var connectionString = ConnectionString;

            return new EmbeddableDocumentStore
            {
                ConnectionStringName = Name
            };
        }

        protected virtual void InitializeDocumentStore(IDocumentStore store)
        {
            store.Conventions.IdentityPartsSeparator = "/";
            store.Conventions.SaveEnumsAsIntegers = false;

            store.Initialize();
        }

        public RavenDocumentRepository ResolveRepository(EntityDefinition definition)
        {
            return new RavenDocumentRepository(definition, this);
        }

        IRavenJObjectRepository IRavenJObjectCatalog.ResolveRepository(EntityDefinition definition)
        {
            return ResolveRepository(definition);
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
    }
}