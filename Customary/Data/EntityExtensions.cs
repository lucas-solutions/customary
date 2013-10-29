using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Raven.Json.Linq;

    public static class EntityExtensions
    {
        public static string GetEntityName(this EntityDefinition definition)
        {
            return definition.Name.Split('/').Last();
        }

        public static EntityDefinition GetParentDefinition(this EntityDefinition definition)
        {
            var parentPath = definition.Extend;

            if (string.IsNullOrEmpty(parentPath))
                return null;

            var parentDiretory = Global.Directory.MatchExact(parentPath);

            var parentDocument = parentDiretory.Value;// Global.Metadata.Session.Load<RavenJObject>(parentDiretory.Key);

            var parentKey = parentDocument.Value<string>("key");

            if (parentKey.StartsWith("Type/Entity/"))
                parentDocument.Deserialize<EntityDefinition>();

            return null;
        }

        public static string GetBaseEntityName(this EntityDefinition definition)
        {
            var parentDefinition = GetParentDefinition(definition);

            return parentDefinition != null ? GetBaseEntityName(parentDefinition) : GetEntityName(definition);
        }
    }
}