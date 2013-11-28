using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Client;
    using global::Raven.Client.Indexes;
    using global::Raven.Json.Linq;

    public abstract class DocumentContext
    {
        private static readonly object _lock = new object();

        [ThreadStatic]
        private static IDocumentSession _session;
        private static DateTime? _startTime;

        private static IDocumentStore _store;

        private readonly string _name;

        protected DocumentContext(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public IDocumentSession Session
        {
            get
            {
                var startTime = System.Web.HttpContext.Current.Items["SessionStartTime"] as Nullable<DateTime>;

                if (!startTime.HasValue)
                {
                        startTime = DateTime.Now;
                        System.Web.HttpContext.Current.Items["SessionStartTime"] = startTime;
                }

                if (_session == null || !_startTime.HasValue || _startTime.Value < startTime.Value)
                {
                    _startTime = startTime;
                    _session = Store.OpenSession();
                }

                return _session;
            }
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

        protected abstract IDocumentStore CreateDocumentStore();

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
    }
}