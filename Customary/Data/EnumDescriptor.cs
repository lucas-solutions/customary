using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using global::Raven.Abstractions.Data;
    using global::Raven.Json.Linq;

    public class EnumDescriptor : TypeDescriptor<EnumDefinition>
    {
        public EnumDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
        }

        public override TypeCategories Category
        {
            get { return TypeCategories.Enum; }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            var enumJObject = this.DataAsJson;
            enumJObject["$type"] = "enum";

            var nameJObject = stack.Peek();
            nameJObject.Remove("$dirty");
            nameJObject["$"] = enumJObject;
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(false);
        }
    }
}