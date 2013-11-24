using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Data.Metadata;
    using Custom.Site.Presentation;
    using global::Raven.Json;
    using global::Raven.Json.Linq;
    using global::Raven.Imports.Newtonsoft;
    using global::Raven.Imports.Newtonsoft.Json;
    using global::Raven.Imports.Newtonsoft.Json.Serialization;
    using Ext = Custom.Site.Presentation.Sencha.Ext;
    
    public static class EntityExtensions
    {
        public static Ext.form.Panel ToForm(this ModelDefinition descriptor)
        {
            var builder = new Ext.form.Panel.Builder();

            return builder;
        }

        public static Ext.grid.Panel ToGrid(this ModelDefinition descriptor)
        {
            var builder = new Ext.grid.Panel.Builder();

            return builder;
        }

        public static Ext.data.Model ToModel(this ModelDefinition descriptor)
        {
            var builder = new Ext.data.Model.Builder();

            return builder;
        }

        public static Ext.data.proxy.Proxy ToProxy(this ModelDefinition descriptor)
        {
            var builder = new Ext.data.proxy.Proxy.Builder();

            return builder;
        }

        public static Ext.data.Store ToStore(this ModelDefinition descriptor)
        {
            var builder = new Ext.data.Store.Builder();

            return builder;
        }

        public static Raven.Json.Linq.RavenJObject ToJObject(this ModelDefinition descriptor)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jo = RavenJObject.FromObject(descriptor, serializer);

            return jo;
        }
    }
}