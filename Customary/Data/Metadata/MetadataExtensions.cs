using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Data.Metadata
{
    using Custom.Data.Persistence;
    using Custom.Data.Serialization;
    using Raven.Abstractions.Data;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public static class MetadataExtensions
    {
        public static bool Import(this Data.Persistence.MetadataContext ctx, string fileName)
        {
            var file = new System.IO.FileInfo(fileName);

            if (!file.Exists)
                return false;

            using (var stream = file.OpenRead())
            {
                var root = RavenJObject.TryLoad(stream);
                var converter = new TypeConverter();

                try
                {
                    var json = root.Value<RavenJArray>("Type").ToString();
                    var types = JsonConvert.DeserializeObject<List<BaseDefinition>>(json, new TypeConverter());
                    foreach (var t in types)
                    {
                        var descriptor = t as TypeDefinition;
                        //descriptor.ID = Guid.NewGuid();
                        ctx.Session.Store(t);
                    }
                    ctx.Session.SaveChanges();

                    foreach (var t in types)
                    {
                        RavenJObject metadata = ctx.Session.Advanced.GetMetadataFor(t);
                    }
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

        public static TypeDefinition Describe(this Data.Persistence.MetadataContext metadata, Guid id)
        {
            var documentId = "Type/" + id.ToString("D");
            var descriptor = System.Web.HttpContext.Current.Items[documentId] as TypeDefinition;
            if (descriptor == null)
            {
                descriptor = metadata.Session.Load<TypeDefinition>(documentId);
                System.Web.HttpContext.Current.Items[documentId] = descriptor;
            }
            return descriptor;
        }

        public static T Describe<T>(this Data.Persistence.MetadataContext context, string name)
            where T : TypeDefinition
        {
            return Describe(context, name) as T;
        }

        public static TypeDefinition Describe(this Data.Persistence.MetadataContext context, string name)
        {
            var descriptor = System.Web.HttpContext.Current.Items[name] as TypeDefinition;

            if (descriptor != null)
                return descriptor;

            RavenJObject record = null;

            /*var indexQuery = new IndexQuery { Query = "Name:" + name };

            var queryResult = context.Store.DatabaseCommands.Query(Indexes.MetadaTypeIndexCreationTask.Name, indexQuery, null);

            var record = queryResult.Results.FirstOrDefault();*/

            var documentResult = context.Store.DatabaseCommands.StartsWith("Type/", "Name:" + name, 0, 1);

            try
            {
                record = context.Session.Advanced.LuceneQuery<RavenJObject, Indexes.MetadaTypeIndexCreationTask>().Where("Name:" + name).FirstOrDefault();
                var id = context.Session.Advanced.GetDocumentId(record);
                record["id"] = id;
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }

            if (record != null)
            {
                descriptor = record.Deserialize<TypeDefinition>(new TypeConverter());
                System.Web.HttpContext.Current.Items[name] = descriptor;
            }

            return descriptor;
        }

        public static string CurrentValue(this Text text)
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

        public static BusinessObject Load(this Data.Persistence.MetadataContext metadata, string id, string type)
        {
            var descriptor = Describe(metadata, type) as ModelDefinition;

            return Load(metadata, id, descriptor);
        }

        public static BusinessObject Load(this Data.Persistence.MetadataContext metadata, string id, ModelDefinition descriptor)
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

        public static void Modify<T>(RavenJToken token, T entity, bool ignoreNull)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    var properties = typeof(T).GetProperties(
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.Instance);
                    var source = (token as RavenJObject);
                    foreach (var prop in properties)
                    {
                        RavenJToken value;
                        if (source.TryGetValue(prop.Name, out value))
                        {
                            switch (value.Type)
                            {
                                case JTokenType.Object:
                                    break;

                                default:
                                    if (!ignoreNull || value.Type != JTokenType.Null)
                                    {
                                        var val = Convert.ChangeType(value.ToString(), prop.PropertyType);
                                        prop.SetValue(entity, val);
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        public static void RegisterIdConventions(this Data.Persistence.MetadataContext metadata)
        {
            metadata.Store.Conventions.DocumentKeyGenerator = (dbname, commands, entity) => metadata.Store.Conventions.GetTypeTagName(entity.GetType()) + "/";
            metadata.Store.Conventions.RegisterIdConvention<TypeDefinition>((dbname, commands, type) => "Type/" + type.Name);
        }

        public static void Validate(this BusinessObject bo)
        {
        }
    }
}