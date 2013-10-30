using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using Raven.Json.Linq;

    public static class ModelExtensions
    {
        public static string GetModelName(this ModelDefinition definition)
        {
            return definition.Name.Split('/').Last();
        }

        public static ModelDefinition GetParentDefinition(this ModelDefinition definition)
        {
            var parentPath = definition.Extend;

            if (string.IsNullOrEmpty(parentPath))
                return null;

            var parentDiretory = Global.Directory.MatchExact(parentPath);

            var parentDocument = parentDiretory.Value;// Global.Metadata.Session.Load<RavenJObject>(parentDiretory.Key);

            var parentKey = parentDocument.Value<string>("key");

            if (parentKey.StartsWith("Type/Model/"))
                parentDocument.Deserialize<ModelDefinition>();

            return null;
        }

        public static string GetBaseModelName(this ModelDefinition definition)
        {
            var parentDefinition = GetParentDefinition(definition);

            return parentDefinition != null ? GetBaseModelName(parentDefinition) : GetModelName(definition);
        }
    }
}