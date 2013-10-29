using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Custom
{
    using Custom.Data.Metadata;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Indexes;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;
    
    public static class DocumentStoreExtensions
    {
        const string idProp = "id";
        const string keyProp = "key";
        const string dataProp = "data";

        #region - Create -

        public static void Create(this IDocumentStore store, RavenJToken data, EntityDefinition descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Create(store, data as RavenJArray, descriptor);
                    break;

                case JTokenType.Object:
                    Create(store, data as RavenJObject, descriptor);
                    break;
            }
        }

        public static void Create(this IDocumentStore store, RavenJArray data, EntityDefinition descriptor = null)
        {
            Create(store, data.Values().AsEnumerable().OfType<RavenJObject>(), descriptor);
        }

        public static void Create(this IDocumentStore store, IEnumerable<RavenJObject> package, EntityDefinition descriptor = null)
        {
            foreach (var record in package)
                Create(store, record, descriptor);
        }

        public static void Create(this IDocumentStore store, RavenJObject record, EntityDefinition descriptor = null)
        {
            throw new NotImplementedException();
        }

        #endregion - Create -

        #region - Destroy -

        public static void Destroy(this IDocumentStore store, RavenJToken data, EntityDefinition descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Destroy(store, data as RavenJArray, descriptor);
                    break;

                case JTokenType.Object:
                    Destroy(store, data as RavenJObject, descriptor);
                    break;
            }
        }

        public static void Destroy(this IDocumentStore store, RavenJArray data, EntityDefinition descriptor = null)
        {
            Destroy(store, data.Values().AsEnumerable().OfType<RavenJObject>(), descriptor);
        }

        public static void Destroy(this IDocumentStore store, IEnumerable<RavenJObject> package, EntityDefinition descriptor = null)
        {
            foreach (var record in package)
                Destroy(store, record, descriptor);
        }

        public static void Destroy(this IDocumentStore store, RavenJObject record, EntityDefinition descriptor = null)
        {
            throw new NotImplementedException();
        }

        #endregion - Destroy -

        #region - Import -

        public static void Import(this IDocumentStore store, string fileName, EntityDefinition descriptor = null)
        {
            Import(store, new FileInfo(fileName), descriptor);
        }

        public static void Import(this IDocumentStore store, FileInfo file, EntityDefinition descriptor = null)
        {
            RavenJObject record;

            using (var reader = file.OpenText())
            {
                record = RavenJObject.Load(new JsonTextReader(reader));
            }

            if (record != null)
            {
                var data = record[dataProp];

                if (data != null && data.Type == JTokenType.Array)
                    Import(store, data as RavenJArray, descriptor);
                else
                    Import(store, record, descriptor);
            }
        }

        public static void Import(this IDocumentStore store, RavenJToken data, EntityDefinition descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Import(store, data as RavenJArray, descriptor);
                    break;

                case JTokenType.Object:
                    Import(store, data as RavenJObject, descriptor);
                    break;
            }
        }

        public static void Import(this IDocumentStore store, RavenJArray data, EntityDefinition descriptor = null)
        {
            Import(store, data.Values().AsEnumerable().OfType<RavenJObject>(), descriptor);
        }

        public static void Import(this IDocumentStore store, IEnumerable<RavenJObject> package, EntityDefinition descriptor = null)
        {
            foreach (var record in package)
                Import(store, record);
        }

        public static bool Import(this IDocumentStore store, RavenJObject record, EntityDefinition descriptor = null)
        {
            var keyToken = record[keyProp];

            var key = keyToken.Value<string>();

            Guid id;
            if (string.IsNullOrWhiteSpace(key) || !Guid.TryParse(key.Split('/').Last(), out id))
                return false;

            record.Remove(keyProp);
            //record.Add(idProp, new RavenJValue(id));

            Import(store, record, key, descriptor);

            return true;
        }

        public static void Import(this IDocumentStore store, RavenJObject record, string key, EntityDefinition descriptor = null)
        {
            if (descriptor != null)
            {
                record.Validate(descriptor, null);
            }

            var metadata = new RavenJObject();
            
            metadata["Raven-Entity-Name"] = new RavenJValue(key.Split('/').First());
            
            var result = store.DatabaseCommands.Put(key, null, record, metadata);

            Debug.Assert(result.Key == key);
        }

        #endregion - Import -

        /*public static List<RavenJObject> Read(this IDocumentStore store, string tagName, int? start, int? pageSize)
        {
            // http://ravendb.net/docs/2.0/client-api/advanced/full-query-syntax?version=2.0

            var indexQuery = new IndexQuery();

            if (start.HasValue)
                indexQuery.Start = start.Value;

            if (pageSize.HasValue)
                indexQuery.PageSize = pageSize.Value;

            indexQuery.Query = "Tag:" + tagName;

            var result = store.DatabaseCommands.Query(new RavenDocumentsByEntityName().IndexName, indexQuery, null);

            return result.Results;
        }*/

        public static List<RavenJObject> Read(this IDocumentStore store, string tagName, int start, int pageSize)
        {
            var documents = store.DatabaseCommands.StartsWith(tagName + '/', null, start, pageSize);
            return documents.Select(o => o.ToRavenJObject()).ToList();
        }

        public static RavenJObject Read(this IDocumentStore store, string key)
        {
            RavenJObject record = null;

            var document = store.DatabaseCommands.Get(key);

            if (document != null)
            {
                record = document.DataAsJson;
                
                //
                // Internal metadata keys
                //
                // Here is a list of all properties RavenDB stores as metadata for its documents:
                //
                // * Raven-Clr-Type - Records the CLR type, set and used by the JSON serialization/deserialization process in the Client API.
                // * Raven-Entity-Name - Records the entity name, aka the name of the RavenDB collection this entity belongs to.
                // * Non-Authoritive-Information - This boolean value will be set to true if the data received by the client has been modified by an uncommitted transaction. You can read more on it in the Advanced section.
                // * Temp-Index-Score - When querying RavenDB, this value is the Lucene score of the entity for the query that was executed.
                // * Raven-Read-Only - This document should be considered read only and not modified.
                // * Last-Modified - The last modified time-stamp for the entity.
                // * @etag - Every document in RavenDB has a corresponding e-tag (entity tag) stored as a sequential Guid. This e-tag is updated by RavenDB every time the document is changed.
                // * @id - The entity id, as extracted from the entity itself.
                //
                // More metadata keys are used for storing replication information, concurrency bookkeeping and ACL used for securing the entity.

                var metadata = document.Metadata;

                //var id = metadata["@id"];
                var etag = metadata["@etag"];
                var lastModified = metadata["Last-Modified"];

                Debug.Assert(string.Equals(key, document.Key, StringComparison.OrdinalIgnoreCase));

                Guid id;
                if (Guid.TryParse(key.Split('/').Last(), out id))
                    record[keyProp] = new RavenJValue(id);

                record["modifiedOn"] = lastModified;
            }

            return record;
        }

        public static IDictionary<string, RavenJObject> ToDictionary(this IEnumerable<RavenJObject> package)
        {
            var dictionary = new Dictionary<string, RavenJObject>();

            var index = 0;
            foreach (var item in package)
            {
                var record = item as RavenJObject;

                if (record == null)
                {
                    continue;
                }

                var key = record.Value<string>(keyProp);

                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;
                }

                if (dictionary.ContainsKey(key))
                {
                    continue;
                }

                record.Remove(keyProp);

                dictionary.Add(key, record);

                index++;
            }

            return dictionary;
        }

        #region - Update -

        public static void Update(this IDocumentStore store, RavenJToken data, EntityDefinition descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Update(store, data as RavenJArray, descriptor);
                    break;

                case JTokenType.Object:
                    Update(store, data as RavenJObject, descriptor);
                    break;
            }
        }

        public static void Update(this IDocumentStore store, RavenJArray data, EntityDefinition descriptor = null)
        {
            Update(store, data.Values().AsEnumerable().OfType<RavenJObject>(), descriptor);
        }

        public static void Update(this IDocumentStore store, IEnumerable<RavenJObject> package, EntityDefinition descriptor = null)
        {
            foreach (var record in package)
                Update(store, record, descriptor);
        }

        public static void Update(this IDocumentStore store, RavenJObject record, EntityDefinition descriptor = null)
        {
            throw new NotImplementedException();
        }

        #endregion - Update -
    }
}