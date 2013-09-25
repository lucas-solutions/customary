using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Metadata;
    using Custom.Presentation;
    using Raven.Json;
    using Raven.Json.Linq;
    using Raven.Imports.Newtonsoft;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;
    using Ext = Custom.Presentation.Sencha.Ext;
    
    public static class EntityExtensions
    {
        public static Ext.form.Panel ToForm(this EntityDescriptor descriptor)
        {
            var builder = new Ext.form.Panel.Builder();

            return builder;
        }

        public static Ext.grid.Panel ToGrid(this EntityDescriptor descriptor)
        {
            var builder = new Ext.grid.Panel.Builder();

            return builder;
        }

        public static Ext.data.Model ToModel(this EntityDescriptor descriptor)
        {
            var builder = new Ext.data.Model.Builder();

            return builder;
        }

        public static Ext.data.proxy.Proxy ToProxy(this EntityDescriptor descriptor)
        {
            var builder = new Ext.data.proxy.Proxy.Builder();

            return builder;
        }

        public static Ext.data.Store ToStore(this EntityDescriptor descriptor)
        {
            var builder = new Ext.data.Store.Builder();

            return builder;
        }

        public static Raven.Json.Linq.RavenJObject ToJObject(this EntityDescriptor descriptor)
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