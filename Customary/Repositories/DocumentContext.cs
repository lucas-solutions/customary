using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Repositories
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Indexes;
    using Raven.Json.Linq;

    public abstract class DocumentContext
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
            //store.Conventions.IdentityPartsSeparator = "-";

            // initialize store
            store.Initialize();

            new RavenDocumentsByEntityName().Execute(store);
        }

        public IDocumentQuery<RavenJObject> Query(string tagName)
        {
            return Query<RavenJObject>(tagName);
        }

        public IDocumentQuery<T> Query<T>(string tagName)
        {
            return Session.Advanced
                .LuceneQuery<T, RavenDocumentsByEntityName>()
                .WhereEquals("Tag", tagName);
        }

        public virtual RavenJObject DataAsJson(JsonDocument document)
        {
            //
            // Internal metadata keys
            //
            // Here is a list of all properties RavenDB stores as metadata for its documents:
            //
            // * Raven-Clr-Type - Records the CLR type, set and used by the JSON serialization/deserialization process in the Client API.
            // * Raven-Entity-Name - Records the entity name, aka the name of the RavenDB collection this entity belongs to.
            // * Non-Authoritive-Information - This boolean value will be set to true if the data received by the client has been modified by an uncommitted transaction. You can read more on it in the Advanced section.
            // * Temp-Index-Score - When querying RavenDB, this value is the Lucene score of the entity for the query that was executed.
            // * Raven-Read-Only - This document should be considered read only and not modified.
            // * Last-Modified - The last modified time-stamp for the entity.
            // * @etag - Every document in RavenDB has a corresponding e-tag (entity tag) stored as a sequential Guid. This e-tag is updated by RavenDB every time the document is changed.
            // * @id - The entity id, as extracted from the entity itself.
            //
            // More metadata keys are used for storing replication information, concurrency bookkeeping and ACL used for securing the entity.

            var json = document.DataAsJson;
            json["etag"] = new RavenJValue(document.Etag.ToString());
            json["id"] = new RavenJValue(document.Key);
            json["modifiedOn"] = new RavenJValue(document.LastModified);

            return json;
        }

        public List<RavenJObject> Read(string tagName, int start, int pageSize)
        {
            var documents = Store.DatabaseCommands.StartsWith(tagName + '/', null, start, pageSize);
            return documents.Select(o => DataAsJson(o)).ToList();
        }

        public RavenJObject Load(string tagName, Guid id)
        {
            var ids = new[]
            {
                tagName + '/' + id.ToString("N")
            };
            var result = Store.DatabaseCommands.Get(ids, null);

            return result.Results.FirstOrDefault();
        }

        public void Put(string tagName, Guid id, RavenJObject data)
        {
            Store.DatabaseCommands.Put(tagName + '/' + id.ToString("N"), null, data, new RavenJObject());
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