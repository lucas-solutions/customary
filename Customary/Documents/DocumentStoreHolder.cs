using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Raven.Client;

    public abstract class DocumentStoreHolder
    {
        private static readonly object _lock = new object();

        [ThreadStatic]
        private static IDocumentSession _session;

        private static IDocumentStore _store;

        public abstract string ConnectionStringName { get; }

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

                    //instance.Conventions.IdentityPartsSeparator = "-";

                    // initialize store
                    store.Initialize();

                    // save store instance
                    _store = store;
                }

                return store;
            }
        }

        protected abstract IDocumentStore CreateDocumentStore();

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