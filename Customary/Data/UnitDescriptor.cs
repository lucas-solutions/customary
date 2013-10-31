using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

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

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(false);
        }
    }
}