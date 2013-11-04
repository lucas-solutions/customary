using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Custom.Data.Serialization;
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

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

            result["id"] = new RavenJValue(Id);
            result["key"] = new RavenJValue(string.Format("{0}/{1}/{2}", Type, Category, _id.ToString(idFormat)));
            result["leaf"] = new RavenJValue(true);
            result["type"] = new RavenJValue(System.Enum.GetName(typeof(TypeCategories), Category));
            result["text"] = new RavenJValue(Name);

            return result;
        }
    }

    public abstract class TypeDescriptor<TDefinition> : TypeDescriptor
        where TDefinition : TypeDefinition
    {
        private TDefinition _definition;

        protected TypeDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
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