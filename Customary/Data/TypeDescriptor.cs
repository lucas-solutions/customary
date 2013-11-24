using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Custom.Data.Serialization;
    using global::Raven.Abstractions.Data;
    using global::Raven.Json.Linq;

    public abstract class TypeDescriptor : NameDescriptor
    {
        private readonly Guid _id;
        protected readonly JsonContext _jsonContext;
        
        protected TypeDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(name, parent)
        {
            _id = id;
            _jsonContext = new JsonContext(jsonDocument);
        }

        public abstract TypeDescriptor BaseType
        {
            get;
        }

        public abstract TypeCategories Category
        {
            get;
        }

        public RavenJObject DataAsJson
        {
            get { return _jsonContext.DataAsJson; }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public string Key
        {
            get { return string.Format("{0}/{1}/{2}", NodeKinds.Type, Category, _id.ToString(idFormat)); }
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Type; }
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var result = new RavenJObject();

            var type = System.Enum.GetName(typeof(TypeCategories), Category);

            result["id"] = new RavenJValue(Id);
            result["key"] = new RavenJValue(string.Format("{0}/{1}/{2}", Type, Category, _id.ToString(idFormat)));
            result["leaf"] = new RavenJValue(true);
            result["type"] = new RavenJValue(type.ToLowerInvariant());
            result["text"] = new RavenJValue(Name);
            result["cls"] = new RavenJValue("metadata" + type);
            result["iconCls"] = new RavenJValue("x-tree-icon-" + type.ToLowerInvariant());

            return result;
        }
    }

    public abstract class TypeDescriptor<TDefinition> : TypeDescriptor
        where TDefinition : TypeDefinition
    {
        private TDefinition _definition;
        private WeakReference<TypeDescriptor> _baseDescriptor;
        private string _baseType;

        protected TypeDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
        }

        public override TypeDescriptor BaseType
        {
            get
            {
                TypeDescriptor target;

                if (_baseDescriptor != null && _baseDescriptor.TryGetTarget(out target))
                    return target;

                if (_baseType == null)
                {
                    var definition = Definition;

                    if (definition == null)
                        return null;

                    _baseType = definition.BaseType ?? string.Empty;
                }

                if (_baseType == string.Empty)
                    return null;

                target = DataDictionary.Current.Describe(_baseType) as ModelDescriptor;

                if (_baseDescriptor != null)
                    _baseDescriptor.SetTarget(target);
                else
                    _baseDescriptor = new WeakReference<TypeDescriptor>(target);

                return target;
            }
        }

        public TDefinition Definition
        {
            get { return /*_definition ?? (_definition = */Deserialize(_jsonContext.DataAsJson)/*)*/; }
        }

        protected virtual TDefinition Deserialize(RavenJObject dataAsJson)
        {
            return dataAsJson.Deserialize<TDefinition>();
        }
    }
}