using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.DocumentModel
{
    using Custom.ComponentModel;
    using Raven.Json.Linq;

    public class Fragment
    {
        internal readonly string _key;
        internal readonly RavenJObject _object;
        internal readonly Document _document;

        public Fragment(string key, ITypeDescriptor descriptor, Document document)
        {
            _key = key;
            _document = document;
            _object = document.Object(key);
        }

        public Document Document
        {
            get { return _document; }
        }

        public Master Master
        {
            get { return _document.Master; }
        }

        public RavenJValue Value(string key)
        {
            return _object.Value<RavenJValue>(key);
        }

        public void Value(string key, RavenJValue v)
        {
            _object[key] = v;
        }
    }
}