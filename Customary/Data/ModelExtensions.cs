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

            var descriptor = DataDictionary.Current.Describe(definition.Extend) as ModelDescriptor;

            return descriptor != null ? descriptor.Definition : null;
        }

        public static string GetBaseModelName(this ModelDefinition definition)
        {
            var parentDefinition = GetParentDefinition(definition);

            return parentDefinition != null ? GetBaseModelName(parentDefinition) : GetModelName(definition);
        }
    }
}