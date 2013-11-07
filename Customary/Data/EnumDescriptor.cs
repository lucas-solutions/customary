using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

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
            var dataAsJson = stack.Peek();

            dataAsJson["$name"] = _name;
            dataAsJson["$type"] = "enum";

            var data = DataAsJson;

            dataAsJson["$members"] = DataAsJson["members"];
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(false);
        }
    }
}