using Raven.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.DocumentModel
{
    public class Document
    {
        internal readonly Master _m;
        internal readonly RavenJObject _o;

        public Document(RavenJObject o, Master m)
        {
            _o = o;
            _m = m;
        }

        public Master Master
        {
            get { return _m; }
        }

        public RavenJArray Array(string key)
        {
            var a = _o.Value<RavenJArray>(key);

            if (a != null)
                return a;

            a = new RavenJArray();

            _o[key] = a;

            return a;
        }

        public RavenJObject Object(string key)
        {
            var o = _o.Value<RavenJObject>(key);

            if (o != null)
                return o;

            o = new RavenJObject();

            _o[key] = o;

            return o;
        }

        public RavenJValue Value(string key)
        {
            return _o.Value<RavenJValue>(key);
        }

        public void Value(string key, RavenJValue v)
        {
            _o[key] = v;
        }
    }
}