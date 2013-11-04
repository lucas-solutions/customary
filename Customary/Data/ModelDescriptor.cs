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
        public static readonly ModelDictionary Dictionary = new ModelDictionary();

        private bool _isBase;
        private string _keyPrefix;
        private WeakReference<ModelDescriptor> _base;
        private string _extend;
        private WeakReference<IRavenJObjectRepository> _repository;

        public ModelDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
            Dictionary[id] = Path;
        }

        public ModelDescriptor Base
        {
            get
            {
                ModelDescriptor target;

                if (_base != null && _base.TryGetTarget(out target))
                    return target;

                if (_extend == null)
                {
                    var definition = Definition;

                    if (definition == null)
                        return null;

                    _extend = definition.Extend ?? string.Empty;
                }

                if (_extend == string.Empty)
                    return null;

                target = DataDictionary.Current.Describe(_extend) as ModelDescriptor;

                if (_base != null)
                    _base.SetTarget(target);
                else
                    _base = new WeakReference<ModelDescriptor>(target);

                return target;
            }
        }

        public string KeyPrefix
        {
            get
            {
                if (_keyPrefix != null)
                    return _keyPrefix;

                for (var model = Base; model != null && !model.Definition.Template; model = model.Base)
                    _keyPrefix = model._name + '/';

                if (_keyPrefix != null)
                    _keyPrefix += _name + '/';
                else
                    _keyPrefix = _name + '/';

                return _keyPrefix;
            }
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

                repository = new Persistence.Repositories.DocumentRepository(this, Global.Metadata);

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
