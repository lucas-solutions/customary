using Raven.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using Raven.Json.Linq;

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

        public RavenJObject DataAsJson
        {
            get { return _jsonContext.DataAsJson; }
        }

        public AreaDefinition Definition
        {
            get { return _jsonContext.DataAsJson.Deserialize<AreaDefinition>(); }
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

            var areaJObject = stack.Peek();
            areaJObject["$"] = this.DataAsJson;
            areaJObject["$type"] = "area";
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var result = new RavenJObject();

            result["id"] = new RavenJValue(Id);
            result["key"] = new RavenJValue(string.Format("{0}/{1}", Type, _id.ToString(idFormat)));
            result["type"] = new RavenJValue(System.Enum.GetName(typeof(NodeKinds), Type).ToLowerInvariant());

            result["text"] = new RavenJValue(Name);

            if (deep)
            {
                var items = _items;

                if (items != null)
                {
                    result["children"] = new RavenJArray(_items.Select(o => o.ToRavenJObject(false)).AsEnumerable<RavenJToken>());
                }
            }

            return result;
        }
    }
}