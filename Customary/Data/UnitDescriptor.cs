using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using global::Raven.Abstractions.Data;
    using global::Raven.Json.Linq;

    public class UnitDescriptor : TypeDescriptor<UnitDefinition>
    {
        public UnitDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
        }

        public override TypeCategories Category
        {
            get { return TypeCategories.Unit; }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            var unitJObject = this.DocumentJObject;
            unitJObject["$type"] = "Metadata/Unit";

            var nameJObject = stack.Peek();
            nameJObject.Remove("$dirty");
            nameJObject["$"] = unitJObject;
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var jObject = base.ToRavenJObject(false);
            jObject["type"] = "Metadata/Unit";
            return jObject;
        }
    }
}