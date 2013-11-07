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
    using System.Diagnostics;

    public class ModelDescriptor : TypeDescriptor<ModelDefinition>
    {
        public static readonly ModelDictionary Dictionary = new ModelDictionary();

        private bool _isBase;
        private string _keyPrefix;
        private WeakReference<IRavenJObjectRepository> _repository;

        public ModelDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
            Dictionary[id] = Path;
        }

        public ModelDescriptor Extend
        {
            get
            {
                var extend = BaseType as ModelDescriptor;
                return extend != null && !extend.Definition.Singleton ? extend : null;
            }
        }

        public string KeyPrefix
        {
            get
            {
                if (_keyPrefix != null)
                    return _keyPrefix;

                for (var model = Extend as ModelDescriptor; model != null; model = model.Extend)
                    _keyPrefix = model._name + '/';

                if (_keyPrefix != null)
                    _keyPrefix += _name + '/';
                else
                    _keyPrefix = _name + '/';

                return _keyPrefix;
            }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            var dataAsJson = stack.Pop();

            dataAsJson["$name"] = _name;
            dataAsJson["$type"] = "model";
            dataAsJson.Remove("$dirty");

            var definition = Definition;
            var fields = new RavenJArray();

            foreach (var property in definition.Properties)
            {
                var field = new RavenJObject();

                field["$name"] = property.Name;

                TypeDescriptor type;
                if (!types.TryGetValue(property.Type, out type))
                {
                    type = DataDictionary.Current.Describe(property.Type) as TypeDescriptor;

                    if (type != null)
                    {
                        types.Add(property.Type, type);
                    }
                }

                if (type != null)
                {
                    switch (type.Category)
                    {
                        case TypeCategories.Enum:
                            field["$type"] = "string";
                            field["$category"] = "enum";
                            field["$source"] = property.Type;
                            break;

                        case TypeCategories.Model:
                            field["$type"] = "string";
                            field["$category"] = "model";
                            field["$model"] = property.Type;
                            break;

                        case TypeCategories.Unit:
                            field["$type"] = "string";
                            field["$category"] = "unit";
                            field["$measure"] = property.Type;
                            break;

                        case TypeCategories.Value:
                            field["$category"] = "value";

                            TypeDescriptor primitive;
                            for (primitive = type; primitive.BaseType != null; primitive = primitive.BaseType)
                            {
                                var key = primitive.Path;
                                if (!types.ContainsKey(key))
                                {
                                    types.Add(key, primitive);
                                }
                            }

                            switch (primitive.Name)
                            {
                                case "Byte":
                                case "Int16":
                                case "Int32":
                                case "Int64":
                                case "UInt16":
                                case "UInt32":
                                case "UInt64":
                                case "SByte":
                                    field["$type"] = "integer";
                                    break;

                                case "Decimal":
                                case "Double":
                                case "Single":
                                    field["$type"] = "number";
                                    break;

                                case "Date":
                                case "Time":
                                case "DateTime":
                                case "DateTimeOffset":
                                    field["$type"] = "date";
                                    break;

                                case "Char":
                                case "String":
                                default:
                                    field["$type"] = "string";
                                    break;
                            }

                            field["$validations"] = property.Type;

                            if (!types.ContainsKey(property.Type))
                            {
                                var propertyType = DataDictionary.Current.Describe(property.Type) as TypeDescriptor;

                                if (type != null)
                                {
                                    types.Add(property.Type, propertyType);

                                    stack.Push(new RavenJObject());
                                    propertyType.Metadata(stack, requires, types);
                                    stack.Merge(stack.Pop(), property.Type);
                                }
                            }

                            break;
                    }
                }

                if (property.Default != null)
                {
                    field["$default"] = new RavenJValue(property.Default);
                }

                field["$role"] = new RavenJValue(System.Enum.GetName(typeof(PropertyRoles), property.Role));

                fields.Add(field);
            }

            dataAsJson["$fields"] = fields;

            stack.Push(dataAsJson);
        }

        public StoreInfo Store
        {
            get
            {
                var stack = new Stack<StoreInfo>();
                stack.Push(Definition.Store);
                for (var ancestor = Parent; ancestor != null; ancestor = ancestor.Parent)
                {
                    switch (ancestor.Type)
                    {
                        case NodeKinds.Area:
                            stack.Push((ancestor as AreaDescriptor).Store);
                            break;
                    }
                }

                StoreInfo store = null;

                while (stack.Count > 0)
                {
                    var s = stack.Pop();

                    if (s == null)
                    {
                        continue;
                    }

                    if (store == null)
                    {
                        store = s;
                        continue;
                    }

                    //
                    // merge s into store

                    if (s.Name != null)
                    {
                        store.Name = s.Name;
                    }

                    if (s.Host != null)
                    {
                        store.Host = null;
                    }
                }

                return store;
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

    public static class RavenJObjectStackExtensions
    {
        public static void Merge(this Stack<RavenJObject> stack, RavenJObject value, string valueName)
        {
            var valuePath = valueName.Split('/');

            var segments = stack.ToList();

            var parent = segments[0];

            for (var i = 0; i < valuePath.Length - 1; i++)
            {
                if (string.Equals(valuePath[i], segments[i].Value<string>("$name"), StringComparison.OrdinalIgnoreCase))
                {
                }
            }
        }
    }
}
