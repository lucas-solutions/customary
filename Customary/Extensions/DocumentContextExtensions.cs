using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Custom.Diagnostics;
    using Custom.Data.Metadata;
    using Custom.Models;
    using Custom.Data.Persistence;
    using Raven.Abstractions.Data;
    using Raven.Client.Indexes;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public static class DocumentContextExtensions
    {
        const string IdProperty = "id";

        public static List<Annotation> Add(this List<Annotation> list, LogCategories category, string message)
        {
            list.Add(new Annotation
            {
                Category = category,
                Message = message
            });

            return list;
        }

        public static RavenJToken Create(this DocumentContext context, RavenJToken source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            switch (source.Type)
            {
                case JTokenType.Array:
                    return Create(context, source as RavenJArray, descriptor, annotations);

                case JTokenType.Object:
                    return Create(context, source as RavenJObject, descriptor, annotations);

                default:
                    annotations.Add(LogCategories.Error, "Object or array expected.");
                    return null;
            }
        }

        public static RavenJArray Create(this DocumentContext context, RavenJArray source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            var array = new RavenJArray();

            foreach (var item in source)
            {
                switch (item.Type)
                {
                    case JTokenType.Object:
                        var record = Create(context, item as RavenJObject, descriptor, annotations);
                        array.Add(record);
                        break;

                    default:
                        annotations.Add(LogCategories.Error, "Only Objects expected on array.");
                        break;
                }
            }

            return array;
        }

        public static RavenJObject Create(this DocumentContext context, RavenJObject source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            Guid idValue;
            RavenJToken idToken;
            if (source.TryGetValue(IdProperty, out idToken) && idToken.Type == JTokenType.Guid)
                idValue = idToken.Value<Guid>();
            else
            {
                idValue = Guid.NewGuid();
                idToken = new RavenJValue(idValue);
                source[IdProperty] = idToken;
            }

            var storeName = descriptor.GetStoreName();
            var documentId = string.Concat(storeName + '/', idValue);

            var record = new RavenJObject();

            record[IdProperty] = idToken;

            UpdateObject(record, source, descriptor, annotations);

            context.Session.Store(record, documentId);
            context.Session.SaveChanges();

            return record;
        }

        public static RavenJArray CopyArray(this RavenJArray sourceArray, TypeDefinition descritor, List<Annotation> annotations)
        {
            var targetArray = new RavenJArray();

            return targetArray;
        }

        public static RavenJValue CopyValue(this RavenJValue sourceValue, TypeDefinition descritor, List<Annotation> annotations)
        {
            // validate value

            var targetValue = sourceValue.CloneToken() as RavenJValue;

            return targetValue;
        }

        public static RavenJToken Destroy(this DocumentContext context, RavenJToken source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            switch (source.Type)
            {
                case JTokenType.Array:
                    return Destroy(context, source as RavenJArray, descriptor, annotations);

                case JTokenType.Object:
                    return Destroy(context, source as RavenJObject, descriptor, annotations);

                default:
                    annotations.Add(LogCategories.Error, "Object or array expected.");
                    return null;
            }
        }

        public static RavenJArray Destroy(this DocumentContext context, RavenJArray source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            var array = new RavenJArray();

            foreach (var item in source)
            {
                switch (item.Type)
                {
                    case JTokenType.Object:
                        var record = Destroy(context, item as RavenJObject, descriptor, annotations);
                        array.Add(record);
                        break;

                    default:
                        annotations.Add(LogCategories.Error, "Only Objects expected on array.");
                        break;
                }
            }

            return array;
        }

        public static RavenJObject Destroy(this DocumentContext context, RavenJObject source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            Guid idValue;
            RavenJToken idToken;
            if (source.TryGetValue(IdProperty, out idToken) && idToken.Type == JTokenType.Guid)
                idValue = idToken.Value<Guid>();
            else
            {
                idValue = Guid.NewGuid();
                idToken = new RavenJValue(idValue);
                source[IdProperty] = idToken;
            }

            var storeName = descriptor.GetStoreName();
            var documentId = string.Concat(storeName + '/', idValue);

            var record = context.Session.Load<RavenJObject>(documentId);

            if (record != null)
            {

                var metadata = context.Session.Advanced.GetMetadataFor(record);
                var etag = context.Session.Advanced.GetEtagFor(record); //metadata.Value<Raven.Abstractions.Data.Etag>("@etag");

                context.Store.DatabaseCommands.Delete(documentId, etag);
                //context.Session.SaveChanges();
            }

            return record;
        }

        public static bool IsArray(this RavenJToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Array:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsObject(this RavenJToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPrimitive(this RavenJToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Date:
                case JTokenType.Float:
                case JTokenType.Guid:
                case JTokenType.Integer:
                case JTokenType.String:
                case JTokenType.TimeSpan:
                case JTokenType.Uri:
                    return true;

                default:
                    return false;
            }
        }

        public static List<RavenJObject> Read(this DocumentContext context, EntityDefinition descriptor, string query, int? start, int? limit, List<Annotation> annotations)
        {
            // http://ravendb.net/docs/2.0/client-api/advanced/full-query-syntax?version=2.0

            var indexQuery = new IndexQuery();

            if (start.HasValue)
                indexQuery.Start = start.Value;

            if (limit.HasValue)
                indexQuery.PageSize = limit.Value;

            if (!string.IsNullOrWhiteSpace(query))
                indexQuery.Query = query;

            var tagName = descriptor.GetStoreName();

            indexQuery.Query = "Tag:" + tagName;

            var result = context.Store.DatabaseCommands.Query(new RavenDocumentsByEntityName().IndexName, indexQuery, null);

            return result.Results;
        }

        public static RavenJToken Update(this DocumentContext context, RavenJToken source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            switch (source.Type)
            {
                case JTokenType.Array:
                    return Update(context, source as RavenJArray, descriptor, annotations);

                case JTokenType.Object:
                    return Update(context, source as RavenJObject, descriptor, annotations);

                default:
                    annotations.Add(LogCategories.Error, "Object or array expected.");
                    return null;
            }
        }

        public static RavenJArray Update(this DocumentContext context, RavenJArray source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            var array = new RavenJArray();

            foreach (var item in source)
            {
                switch (item.Type)
                {
                    case JTokenType.Object:
                        var record = Update(context, item as RavenJObject, descriptor, annotations);
                        array.Add(record);
                        break;

                    default:
                        annotations.Add(LogCategories.Error, "Only Objects expected on array.");
                        break;
                }
            }

            return array;
        }

        public static RavenJObject Update(this DocumentContext context, RavenJObject source, EntityDefinition descriptor, List<Annotation> annotations)
        {
            RavenJObject record = null;
            RavenJToken idToken;
            if (source.TryGetValue(IdProperty, out idToken) && idToken.Type == JTokenType.Guid)
            {
                var idValue = idToken.Value<Guid>();

                var storeName = descriptor.GetStoreName();
                var documentId = string.Concat(storeName + '/', idValue);

                record = context.Session.Load<RavenJObject>(documentId);

                if (record != null)
                {
                    RavenJObject metadata = context.Session.Advanced.GetMetadataFor(record);

                    // Get the last modified time stamp, which is known to be of type DateTime
                    DateTime modifiedOn = metadata.Value<DateTime>("Last-Modified");

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

                    UpdateObject(record, source, descriptor, annotations);

                    context.Session.Store(record);
                }
                else
                {
                    annotations.Add(LogCategories.Error, string.Format("Could not find document {0}", documentId));
                }
            }
            return record;
        }

        public static RavenJArray UpdateArray(this RavenJArray targetArray, RavenJArray sourceArray, TypeDefinition descritor, List<Annotation> annotations)
        {
            return targetArray;
        }

        public static RavenJObject UpdateObject(this RavenJObject targetObject, RavenJObject sourceObject, StructuralDefinition objectDescriptor, List<Annotation> annotations)
        {
            foreach (var property in objectDescriptor.Properties)
            {
                var sourceValue = sourceObject.Value<RavenJToken>(property.Name);

                if (sourceValue == null)
                    continue;

                var targetValue = targetObject.Value<RavenJToken>(property.Name);

                if (string.IsNullOrWhiteSpace(property.PropertyType))
                {
                    annotations.Add(LogCategories.Debug, string.Format("PropertyType for property {1} not defined. Type: {0}", objectDescriptor.Name, property.Name));
                    continue;
                }

                var propertyType = Global.Metadata.Describe(property.PropertyType);

                if (propertyType == null)
                    continue;

                if (property.Role == PropertyRoles.HasMany)
                {
                    if (!sourceValue.IsArray())
                    {
                        annotations.Add(LogCategories.Debug, string.Format("Array expected for property {1}. Type: {0}", objectDescriptor.Name, property.Name));
                        continue;
                    }
                    else if (targetValue != null && targetValue.IsArray())
                        UpdateArray(targetValue as RavenJArray, sourceValue as RavenJArray, propertyType, annotations);
                    else
                    {
                        targetValue = CopyArray(sourceValue as RavenJArray, propertyType, annotations);
                        targetObject[property.Name] = targetValue;
                    }
                }
                else if (propertyType is ValueDefinition)
                {
                    if (!sourceValue.IsPrimitive())
                    {
                        annotations.Add(LogCategories.Debug, string.Format("Primitive of type {2} expected for property {1}. Type: {0}", objectDescriptor.Name, property.Name, property.PropertyType));
                        continue;
                    }
                    else
                    {
                        targetValue = CopyValue(sourceValue as RavenJValue, propertyType, annotations);

                        if (targetValue != null)
                            targetObject[property.Name] = targetValue;
                    }
                }
                else if (propertyType is EntityDefinition)
                {
                    if (!sourceValue.IsPrimitive())
                    {
                        annotations.Add(LogCategories.Debug, string.Format("Primitive of type {2} expected for property {1}. Type: {0}", objectDescriptor.Name, property.Name, propertyType.Name));
                        continue;
                    }
                    else
                    {
                        targetValue = CopyValue(sourceValue as RavenJValue, propertyType, annotations);

                        if (targetValue != null)
                            targetObject[property.Name] = targetValue;
                    }
                }
                else if (propertyType is StructuralDefinition)
                {
                    if (!sourceValue.IsObject())
                        continue;
                }
            }

            return targetObject;
        }

        public static string GetStoreName(this EntityDefinition descriptor)
        {
            if (descriptor.Store != null && !string.IsNullOrWhiteSpace(descriptor.Store.Name))
                return descriptor.Store.Name;

            var firstName = descriptor.Name.Split('.').Last();

            if (string.IsNullOrWhiteSpace(descriptor.Extend))
                return firstName;

            var familyName = GetFamilyName(descriptor);

            if (string.IsNullOrEmpty(familyName))
                return firstName;

            return familyName + '/' + firstName;
        }

        public static string GetFamilyName(this EntityDefinition descriptor)
        {
            if (!string.IsNullOrWhiteSpace(descriptor.Extend))
            {
                var parent = Global.Metadata.Describe(descriptor.Extend) as EntityDefinition;

                if (parent != null)
                    return GetStoreName(parent);
            }

            return descriptor.Name.Split('.').Last();
        }
    }
}