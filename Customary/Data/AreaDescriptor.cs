using global::Raven.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using global::Raven.Json.Linq;

    public class AreaDescriptor : NameDescriptor
    {
        private readonly Guid _id;
        private readonly JsonContext _jsonContext;

        public AreaDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(name, parent)
        {
            _id = id;
            _jsonContext = new JsonContext(jsonDocument);
        }

        public StoreInfo Store
        {
            get
            {
                StoreInfo store = null;

                return store;
            }
        }

        public RavenJObject DocumentJObject
        {
            get { return _jsonContext.DocumentJObject; }
        }

        public RavenJObject DocumentMetadata
        {
            get { return _jsonContext.DocumentMetadata; }
        }

        public AreaDefinition Definition
        {
            get { return _jsonContext.DocumentJObject.Deserialize<AreaDefinition>(); }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Area; }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            base.Metadata(stack, requires, types);

            var areaJObject = this.DocumentJObject;
            areaJObject["$type"] = "Metadata/Area";

            var nameJObject = stack.Peek();
            nameJObject["$"] = areaJObject;
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var ravenJObject = base.ToRavenJObject(deep);
            var metadata = DocumentMetadata;

            ravenJObject["Id"] = new RavenJValue(Id);
            ravenJObject["key"] = new RavenJValue(string.Format("{0}/{1}", Type, _id.ToString(idFormat)));
            ravenJObject["Type"] = "Metadata/Area";

            ravenJObject["Title"] = DocumentJObject["Title"];
            ravenJObject["LastModified"] = metadata["Last-Modified"];

            if (deep)
            {
                var items = _items;

                if (items != null)
                {
                    ravenJObject["children"] = new RavenJArray(_items.Select(o => o.ToRavenJObject(false)).AsEnumerable<RavenJToken>());
                }
            }

            return ravenJObject;
        }
    }
}