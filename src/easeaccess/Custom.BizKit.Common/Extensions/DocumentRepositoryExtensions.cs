using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Custom.Documents;
    using Custom.Repositories;
    using Newtonsoft.Json;
    

    public static class DocumentRepositoryExtensions
    {
        public static TEntity Save<TEntity>(this DocumentRepository<TEntity> repo, string json)
            where TEntity : class, new()
        {
            var entity = JsonConvert.DeserializeObject<TEntity>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            repo.Save(entity);

            return entity;
        }

        public static TEntity Store<TEntity>(this DocumentRepository<TEntity> repo, string json)
            where TEntity : class, new()
        {
            var entity = JsonConvert.DeserializeObject<TEntity>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            repo.Store(entity);

            return entity;
        }
    }
}
