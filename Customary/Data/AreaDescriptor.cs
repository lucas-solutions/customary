using Raven.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
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

        public StoreInfo Catalog
        {
            get { return null; }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Area; }
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var result = new RavenJObject();

            result["id"] = new RavenJValue(Id);
            result["key"] = new RavenJValue(string.Format("{0}/{1}", Type, _id.ToString(idFormat)));
            result["type"] = new RavenJValue(System.Enum.GetName(typeof(NodeKinds), Type));

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