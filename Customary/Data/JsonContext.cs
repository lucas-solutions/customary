using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Client;
    using global::Raven.Json.Linq;

    public class JsonContext
    {
        private readonly string _key;
        private WeakReference<JsonDocument> _jsonDocument;
        private WeakReference<RavenJObject> _documentJObject;
        private WeakReference<RavenJObject> _metadataJObject;

        public JsonContext(JsonDocument jsonDocument)
        {
            _key = jsonDocument.Key;
            _jsonDocument = new WeakReference<JsonDocument>(jsonDocument);
        }

        public JsonDocument Document
        {
            get
            {
                if (string.IsNullOrEmpty(_key))
                    return null;

                JsonDocument document;

                if (_jsonDocument.TryGetTarget(out document))
                    return document;

                document = Global.Metadata.Store.DatabaseCommands.Get(_key);

                _jsonDocument.SetTarget(document);

                return document;
            }
        }

        public RavenJObject DocumentJObject
        {
            get
            {
                RavenJObject documentJObject;

                if (_documentJObject != null && _documentJObject.TryGetTarget(out documentJObject))
                    return documentJObject;

                documentJObject = Document.DataAsJson;

                documentJObject.EnsureSnapshot(string.Empty);

                documentJObject = documentJObject.CreateSnapshot() as RavenJObject;

                if (_documentJObject != null)
                    _documentJObject.SetTarget(documentJObject);
                else
                    _documentJObject = new WeakReference<RavenJObject>(documentJObject);

                return documentJObject;
            }
        }

        public RavenJObject DocumentMetadata
        {
            get
            {
                RavenJObject metadataJObject;

                if (_metadataJObject != null && _metadataJObject.TryGetTarget(out metadataJObject))
                    return metadataJObject;

                var ravenJObject = Global.Metadata.Session.Load<RavenJObject>(_key);
                metadataJObject = Global.Metadata.Session.Advanced.GetMetadataFor<RavenJObject>(ravenJObject);

                //metadataJObject = Document.Metadata;

                if (_metadataJObject != null)
                    _metadataJObject.SetTarget(metadataJObject);
                else
                    _metadataJObject = new WeakReference<RavenJObject>(metadataJObject);

                return metadataJObject;
            }
        }

        public string Key
        {
            get { return _key; }
        }

        public static int Compare(JsonDocument x, JsonDocument y)
        {
            int result;

            result = string.Compare(x.DataAsJson.Value<string>("name"), y.DataAsJson.Value<string>("name"), true);

            return result;
        }
    }
}