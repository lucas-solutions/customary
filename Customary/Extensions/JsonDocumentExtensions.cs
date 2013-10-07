using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom
{
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

    public static class JsonDocumentExtensions
    {
        public static RavenJObject ToRavenJObject(this JsonDocument document)
        {
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

            var record = document.DataAsJson;
            record["id"] = new RavenJValue(document.Key);
            record["etag"] = new RavenJValue(document.Etag.ToString());
            record["Last-Modified"] = new RavenJValue(document.LastModified);

            return record;
        }
    }
}