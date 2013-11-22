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

        public string KeyPrefix
        {
            get
            {
                if (_keyPrefix != null)
                {
                    return _keyPrefix;
                }

                var stack = new Stack<string>();

                stack.Push(string.Empty);
                stack.Push(_name);

                for (var baseModel = BaseType as ModelDescriptor as ModelDescriptor; baseModel != null && !baseModel.Definition.Embeddable; baseModel = baseModel.BaseType as ModelDescriptor)
                {
                    stack.Push(baseModel._name);
                }

                _keyPrefix = string.Join("/", stack);

                return _keyPrefix;
            }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            var modelJObject = this.DataAsJson;
            modelJObject["$type"] = "model";

            var nameJObject = stack.Pop();
            nameJObject.Remove("$dirty");
            nameJObject["$"] = modelJObject;

            var definition = Definition;

            var baseName = definition.BaseType;

            if (!string.IsNullOrEmpty(baseName))
            {
                nameJObject["$base"] = baseName;

                if (!types.ContainsKey(baseName))
                {
                    var baseType = BaseType;

                    types.Add(baseName, baseType);

                    if (baseType != null)
                    {
                        stack.Push(new RavenJObject());
                        baseType.Metadata(stack, requires, types);
                        stack.Merge(baseName, stack.Pop());
                    }
                }
            }

            if (definition.Embeddable)
            {
                //namespaceJObject["$embeddable"] = true;
            }

            if (!string.IsNullOrEmpty(definition.BelongsTo))
            {
                //namespaceJObject["$belongsTo"] = definition.BelongsTo;
            }

            //namespaceJObject.SetCurrentThreadCultureText("$title", definition.Title);
            //namespaceJObject.SetCurrentThreadCultureText("$summary", definition.Summary);

            var fields = new RavenJArray();

            foreach (var property in definition.Properties)
            {
                //var fieldJObject = new RavenJObject();

                //fieldJObject["$name"] = property.Name;

                //fieldJObject.SetCurrentThreadCultureText("$title", property.Title);
                //fieldJObject.SetCurrentThreadCultureText("$summary", property.Summary);

                TypeDescriptor propertyType;
                if (!types.TryGetValue(property.Type, out propertyType))
                {
                    propertyType = DataDictionary.Current.Describe(property.Type) as TypeDescriptor;

                    if (propertyType != null)
                    {
                        types.Add(property.Type, propertyType);

                        stack.Push(new RavenJObject());
                        propertyType.Metadata(stack, requires, types);
                        stack.Merge(property.Type, stack.Pop());
                    }
                }

                if (propertyType == null)
                {
                    //fieldJObject["$type"] = "string";
                    //fieldJObject["$category"] = "value";
                }
                else
                {
                    switch (propertyType.Category)
                    {
                        case TypeCategories.Enum:
                            //fieldJObject["$type"] = "string";
                            //fieldJObject["$category"] = "enum";
                            //fieldJObject["$prototype"] = property.Type;
                            break;

                        case TypeCategories.Model:
                            //fieldJObject["$type"] = "string";
                            //fieldJObject["$category"] = "model";
                            //fieldJObject["$prototype"] = property.Type;
                            //if (property.IdProperty != null)
                            //{
                            //    fieldJObject["$id"] = property.IdProperty;
                            //}
                            break;

                        case TypeCategories.Unit:
                            //fieldJObject["$type"] = "string";
                            //fieldJObject["$category"] = "unit";
                            //fieldJObject["$prototype"] = property.Type;
                            break;

                        case TypeCategories.Value:
                            //fieldJObject["$category"] = "value";

                            TypeDescriptor primitive;
                            for (primitive = propertyType; primitive.BaseType != null; primitive = primitive.BaseType)
                            {
                                var key = primitive.Path;
                                if (!types.ContainsKey(key))
                                {
                                    types.Add(key, primitive);
                                }
                            }

                            switch (primitive.Name)
                            {
                                case "Boolean":
                                    //fieldJObject["$type"] = "boolean";
                                    break;

                                case "Byte":
                                case "Int16":
                                case "Int32":
                                case "Int64":
                                case "UInt16":
                                case "UInt32":
                                case "UInt64":
                                case "SByte":
                                    //fieldJObject["$type"] = "integer";
                                    break;

                                case "Decimal":
                                case "Double":
                                case "Single":
                                    //fieldJObject["$type"] = "number";
                                    break;

                                case "Date":
                                case "Time":
                                case "DateTime":
                                case "DateTimeOffset":
                                    //fieldJObject["$type"] = "date";
                                    break;

                                case "Text":
                                    //fieldJObject["$type"] = "text";
                                    break;

                                case "Char":
                                case "String":
                                default:
                                    //fieldJObject["$type"] = "string";
                                    break;
                            }

                            //fieldJObject["$prototype"] = property.Type;

                            break;
                    }
                }

                if (property.Default != null)
                {
                    //fieldJObject["$default"] = new RavenJValue(property.Default);
                }

                //fieldJObject["$role"] = new RavenJValue(System.Enum.GetName(typeof(PropertyRoles), property.Role));

                //fields.Add(fieldJObject);
            }

            //modelJObject["$fields"] = fields;

            stack.Push(nameJObject);
        }

        public StoreInfo Store
        {
            get
            {
                var stack = new Stack<StoreInfo>();
                var storeName = Definition.Store;
                StoreInfo store = null;
                /*stack.Push(store);
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
                }*/

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
            var result = new RavenJObject();

            var type = System.Enum.GetName(typeof(TypeCategories), Category);

            result["id"] = new RavenJValue(Id);
            result["key"] = new RavenJValue(KeyPrefix + Id.ToString(idFormat));
            result["leaf"] = new RavenJValue(true);
            result["type"] = new RavenJValue(type.ToLowerInvariant());
            result["text"] = new RavenJValue(Name);
            result["cls"] = new RavenJValue("metadata" + type);
            result["iconCls"] = new RavenJValue("x-tree-icon-" + type.ToLowerInvariant());

            return result;
        }
    }

    public static class RavenJObjectStackExtensions
    {
        public static string Key(this RavenJObject nameJObject, string name)
        {
            return nameJObject.Keys.FirstOrDefault(key => string.Equals(key, name, StringComparison.OrdinalIgnoreCase));
        }

        public static void Merge(this Stack<RavenJObject> stack, string name, RavenJObject value)
        {
            var valuePath = name.Split('/');

            var currentJObject = stack.Last();
            
            for (var i = 0; i < valuePath.Length - 1; i++)
            {
                var nextName = valuePath[i];

                var nextJObject = currentJObject.Value<RavenJObject>(nextName);

                if (nextJObject == null)
                {
                    nextJObject = new RavenJObject();
                    nextJObject["$dirty"] = true;
                    currentJObject[nextName] = nextJObject;
                }

                currentJObject = nextJObject;
            }

            currentJObject[valuePath[valuePath.Length - 1]] = value;
        }
    }
}
