using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Serialization;
    using Newtonsoft.Json;
    using Raven.Json.Linq;

    public static class MetadataExtensions
    {
        public static bool Import(this Documents.Metadata metadata, string fileName)
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
                    //Types = JsonConvert.DeserializeObject<List<MemberDescriptor>>(json, new MemberConverter());
                }
                catch (Exception e)
                {
                    var msg = e.Message;
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

        public static TypeDescriptor Describe(this Documents.Metadata metadata, string name)
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

        public static BusinessObject Load(this Documents.Metadata metadata, string id, string type)
        {
            var descriptor = Describe(metadata, type) as EntityDescriptor;

            return Load(metadata, id, descriptor);
        }

        public static BusinessObject Load(this Documents.Metadata metadata, string id, EntityDescriptor descriptor)
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

        public static void RegisterIdConventions(this Documents.Metadata metadata)
        {
            metadata.Store.Conventions.DocumentKeyGenerator = (dbname, commands, entity) => metadata.Store.Conventions.GetTypeTagName(entity.GetType()) + "/";
            metadata.Store.Conventions.RegisterIdConvention<TypeDescriptor>((dbname, commands, type) => "Type/" + type.Name);
        }

        public static void Validate(this BusinessObject bo)
        {
        }
    }
}