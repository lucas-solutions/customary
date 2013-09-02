using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public abstract class Document
    {
        protected readonly string _key;
        protected readonly RavenJObject _value;

        protected Document(RavenJObject value)
            : this("Id", value)
        {
        }

        protected Document(string key, RavenJObject value)
        {
            _key = key;
            _value = value;
        }

        public string Key
        {
            get { return _key; }
        }

        public string Id
        {
            get { return _value.Value<string>(_key); }
            set { _value[_key] = value; }
        }

        public override string ToString()
        {
            return _value[_key].ToString();
        }
    }

    public abstract class Document<TObject> : Document
        where TObject : class
    {
        protected Document(string key, RavenJObject value)
            : base(key, value)
        {
        }
    }
}
