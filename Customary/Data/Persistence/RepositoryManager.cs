using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using Custom.Data.Persistence.Repositories;

    public class RepositoryManager
    {
        private ConcurrentDictionary<string, Func<DocumentContext>> _lazyDocumentContextMap;

        public RepositoryManager()
        {
            var knownDodumentContextMap = new Dictionary<string, Func<DocumentContext>>
            {
                { "Globalization", () => { return Global.Globalization; } },
                { "Metadata", () => { return Global.Metadata; } },
                { "Masterdata", () => { return Global.Masterdata; } },
                { "Navigation", () => { return Global.Navigation; } }
            };

            _lazyDocumentContextMap = new ConcurrentDictionary<string, Func<DocumentContext>>(knownDodumentContextMap);
        }

        public IRavenJObjectRepository this[Guid id]
        {
            get { return ResolveRepository(id); }
        }

        public IRavenJObjectRepository this[ModelDefinition definition]
        {
            get { return ResolveRepository(definition); }
        }

        public IRavenJObjectRepository ResolveRepository(Guid id)
        {
            var definitionKey = string.Concat("Type/Model/", id);

            var definition = Global.Metadata.Session.Load<Custom.Data.Metadata.ModelDefinition>(definitionKey);

            return definition != null ? ResolveRepository(definition) : null;
        }

        public IRavenJObjectRepository ResolveRepository(ModelDefinition definition)
        {
            var catalog = ResolveCatalog(definition);

            if (definition.Singleton)
            {
                var context = ResolveDocumentContext(catalog.Name);
                return null;
            }

            switch (catalog.Type)
            {
                case StoreTypes.Ajax:
                    return new AjaxRepository();

                case StoreTypes.Doument:
                    {
                        var context = ResolveDocumentContext(catalog.Name);
                        return new DocumentRepository(catalog, definition, context);
                    }

                case StoreTypes.Procedural:
                    return new ProceduralRepository();

                case StoreTypes.Record:
                    return new RecordRepository();

                case StoreTypes.Restful:
                    return new RestfulRepository();

                default:
                    return null;
            }
        }

        public StoreInfo ResolveCatalog(ModelDefinition definition)
        {
            StoreInfo catalog = null;

            if (definition.Repository != null)
            {
                catalog = definition.Repository.Catalog;
            }

            return catalog;
        }

        public DocumentContext ResolveDocumentContext(string name)
        {
            Func<DocumentContext> lazyContext;
            if (!_lazyDocumentContextMap.TryGetValue(name, out lazyContext))
            {
                lazyContext = () => { return new EmbeddableDocumentContext(name); };

            }

            return lazyContext();
        }
    }
}