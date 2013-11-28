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

        public RavenJObject DocumentJObject
        {
            get { return _jsonContext.DocumentJObject; }
        }

        public RavenJObject DocumentMetadata
        {
            get { return _jsonContext.DocumentMetadata; }
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
            var ravenJObject = base.ToRavenJObject(false);
            var metadata = DocumentMetadata;

            ravenJObject["Id"] = new RavenJValue(Id);
            ravenJObject["Name"] = new RavenJValue(Path);
            ravenJObject["Title"] = DocumentJObject["Title"];

            switch (Category)
            {
                case TypeCategories.Enum:
                    ravenJObject["Type"] = "Metadata/Enum";
                    break;

                case TypeCategories.Model:
                    ravenJObject["Type"] = "Metadata/Model";
                    break;

                case TypeCategories.Unit:
                    ravenJObject["Type"] = "Metadata/Unit";
                    break;

                case TypeCategories.Value:
                    ravenJObject["Type"] = "Metadata/Value";
                    break;
            }

            ravenJObject["LastModified"] = metadata["Last-Modified"];

            var type = System.Enum.GetName(typeof(TypeCategories), Category);

            ravenJObject["key"] = new RavenJValue(string.Format("{0}/{1}/{2}", Type, Category, _id.ToString(idFormat)));
            ravenJObject["leaf"] = new RavenJValue(true);
            ravenJObject["cls"] = new RavenJValue("metadata" + type);
            ravenJObject["iconCls"] = new RavenJValue("x-tree-icon-" + type.ToLowerInvariant());

            return ravenJObject;
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
            get { return /*_definition ?? (_definition = */Deserialize(_jsonContext.DocumentJObject)/*)*/; }
        }

        protected virtual TDefinition Deserialize(RavenJObject dataAsJson)
        {
            return dataAsJson.Deserialize<TDefinition>();
        }
    }
}