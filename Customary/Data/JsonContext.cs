using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Json.Linq;

    public class JsonContext
    {
        private readonly string _key;
        private WeakReference<JsonDocument> _jsonDocument;
        private WeakReference<RavenJObject> _dataAsJson;

        public JsonContext(JsonDocument jsonDocument)
        {
            _key = jsonDocument.Key;
            _jsonDocument = new WeakReference<JsonDocument>(jsonDocument);
        }

        public RavenJObject DataAsJson
        {
            get
            {
                RavenJObject dataAsJson;

                if (_dataAsJson != null && _dataAsJson.TryGetTarget(out dataAsJson))
                    return dataAsJson;

                dataAsJson = Document.DataAsJson.CreateSnapshot() as RavenJObject;

                if (_dataAsJson != null)
                    _dataAsJson.SetTarget(dataAsJson);
                else
                    _dataAsJson = new WeakReference<RavenJObject>(dataAsJson);

                return dataAsJson;
            }
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

        public string Key
        {
            get { return _key; }
        }

        protected static int Compare(JsonDocument x, JsonDocument y)
        {
            int result;

            result = string.Compare(x.DataAsJson.Value<string>("Name"), y.DataAsJson.Value<string>("Name"), true);

            return result;
        }
    }
}