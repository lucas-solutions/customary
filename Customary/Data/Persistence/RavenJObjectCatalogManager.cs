using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    public class RavenJObjectCatalogManager
    {
        private readonly ConcurrentDictionary<string, IRavenJObjectCatalog> _dictionary;

        public RavenJObjectCatalogManager()
        {
            _dictionary = new ConcurrentDictionary<string, IRavenJObjectCatalog>();
        }

        public IRavenJObjectCatalog this[string name]
        {
            get
            {
                IRavenJObjectCatalog catalog;

                if (!_dictionary.TryGetValue(name, out catalog))
                    _dictionary.AddOrUpdate(
                        name,
                        catalog = new RavenDocumentCatalog(name),
                        (string key, IRavenJObjectCatalog other) => { return catalog = other; }
                    );

                return catalog;
            }
        }
    }
}