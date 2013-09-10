﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Repositories;
    using Custom.Serialization;
    using Newtonsoft.Json;
    using Raven.Json.Linq;

    public static class MetadataExtensions
    {
        public static bool Import(this Repositories.MetadataContext ctx, string fileName)
        {
            var file = new System.IO.FileInfo(fileName);

            if (!file.Exists)
                return false;

            using (var stream = file.OpenRead())
            {
                var root = RavenJObject.TryLoad(stream);
                var converter = new MemberConverter();

                try
                {
                    var json = root.Value<RavenJArray>("Type").ToString();
                    var types = JsonConvert.DeserializeObject<List<MemberDescriptor>>(json, new MemberConverter());
                    foreach (var t in types)
                    {
                        ctx.Session.Store(t);
                    }
                    ctx.Session.SaveChanges();
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    Global.Logger.LogError(msg, e);
                }
                /*
                 foreach (var typesJArray in root.Value<RavenJArray>("Types"))
                 {
                     foreach (var typeJObject in typesJArray.Values<RavenJObject>())
                     {
                         var descriptor = converter
                     }
                 }*/
            }

            return true;
        }

        public static TypeDescriptor Describe(this Repositories.MetadataContext metadata, string name)
        {
            var id = "Type/" + name;
            var descriptor = System.Web.HttpContext.Current.Items[id] as TypeDescriptor;
            if (descriptor == null)
            {
                descriptor = metadata.Session.Load<TypeDescriptor>(id);
                System.Web.HttpContext.Current.Items[id] = descriptor;
            }
            return descriptor;
        }

        public static string CurrentValue(this TextObject text)
        {
            string value = text.Values.FirstOrDefault();
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            for (var i = 0; i < text.Count && culture.Name != ""; culture = culture.Parent)
            {
                if (text.TryGetValue(culture.Name, out value))
                    break;
            }
            return value;
        }

        public static BusinessObject Load(this Repositories.MetadataContext metadata, string id, string type)
        {
            var descriptor = Describe(metadata, type) as EntityDescriptor;

            return Load(metadata, id, descriptor);
        }

        public static BusinessObject Load(this Repositories.MetadataContext metadata, string id, EntityDescriptor descriptor)
        {
            if (descriptor == null)
                throw new InvalidOperationException();

            var data = metadata.Session.Load<RavenJObject>(id);

            if (data == null)
                throw new InvalidOperationException();

            var bo = new BusinessObject(data, descriptor);

            return bo;
        }

        public static BusinessObject Merge(this BusinessObject bo, params RavenJObject[] sources)
        {
            var target = bo._data;
            var descriptor = bo._descriptor;

            foreach (var source in sources)
            {
            }

            return bo;
        }

        public static void RegisterIdConventions(this Repositories.MetadataContext metadata)
        {
            metadata.Store.Conventions.DocumentKeyGenerator = (dbname, commands, entity) => metadata.Store.Conventions.GetTypeTagName(entity.GetType()) + "/";
            metadata.Store.Conventions.RegisterIdConvention<TypeDescriptor>((dbname, commands, type) => "Type/" + type.Name);
        }

        public static void Validate(this BusinessObject bo)
        {
        }

        public static void AddOrUpdate(this MetadataContext ctx, TypeDescriptor type, Func<TypeDescriptor, TypeDescriptor> updateFactory)
        {
            var original = ctx.Session.Load<TypeDescriptor>(type.ID);
            if (original != null)
            {
                if (updateFactory != null)
                {
                    type = updateFactory(original);
                }
                else
                {
                    // merge
                }
            }
            ctx.Session.Store(original);
            ctx.Session.SaveChanges();
        }

        public static bool TryAdd(this MetadataContext ctx, TypeDescriptor type)
        {
            var original = ctx.Session.Load<TypeDescriptor>(type.ID);
            if (original != null)
                return false;

            ctx.Session.Store(type);

            return true;
        }

        public static bool TryDescribe(this MetadataContext ctx, Guid id, out TypeDescriptor type)
        {
            type = ctx.Session.Load<TypeDescriptor>(id);
            return type != null;
        }

        public static bool TryDescribe(this MetadataContext ctx, string name, string ns, out TypeDescriptor type)
        {
            type = ctx.Session.Query<TypeDescriptor>().FirstOrDefault(o => o.Name == name && o.Namespace == ns);
            return type != null;
        }

        public static bool TryUpdate(this MetadataContext ctx, TypeDescriptor type)
        {
            return true;
        }

        public static bool TryRemove(this MetadataContext ctx, TypeDescriptor type)
        {
            return true;
        }

        public static bool TryRemove(this MetadataContext ctx, Guid id)
        {
            return true;
        }

        public static bool TryRemove(this MetadataContext ctx, string name, string ns)
        {
            return true;
        }
    }
}