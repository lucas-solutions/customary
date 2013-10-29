using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    public class RepositoryManager
    {
        private readonly ConcurrentDictionary<string, IRavenJObjectCatalog> _stores;
        
        public RepositoryManager()
        {
            _stores = new ConcurrentDictionary<string, IRavenJObjectCatalog>();
        }

        public IRavenJObjectRepository this[Guid id]
        {
            get { return ResolveRepository(id); }
        }

        public IRavenJObjectRepository this[string catalog, string principal, string discriminator]
        {
            get
            {
                var store = ResolveStore(catalog);
                return null;
            }
        }

        public IRavenJObjectCatalog ResolveStore(string name)
        {
            IRavenJObjectCatalog store = null;

            return store;
        }

        public IRavenJObjectRepository ResolveRepository(Guid id)
        {
            var definitionKey = string.Concat("Type/Entity/", id);

            var definition = Global.Metadata.Session.Load<Custom.Data.Metadata.EntityDefinition>(definitionKey);

            IRavenJObjectRepository repo = null;

            return repo;
        }
    }
}