using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

    public class ModelDescriptor : TypeDescriptor<ModelDefinition>
    {
        private WeakReference<IRavenJObjectRepository> _repository;

        public ModelDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
        }

        public StoreInfo Store
        {
            get
            {
                return null;
            }
        }

        public IRavenJObjectRepository Repository
        {
            get
            {
                IRavenJObjectRepository repository;

                if (_repository != null && _repository.TryGetTarget(out repository))
                    return repository;

                var store = Store;

                repository = null;

                if (_repository != null)
                    _repository.SetTarget(repository);
                else
                    _repository = new WeakReference<IRavenJObjectRepository>(repository);

                return repository;
            }
        }

        public override TypeCategories Category
        {
            get { return TypeCategories.Model; }
        }

        protected override ModelDefinition Deserialize(RavenJObject dataAsJson)
        {
            var definition = base.Deserialize(dataAsJson);

            return definition;
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(false);
        }
    }
}
