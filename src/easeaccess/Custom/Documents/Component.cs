using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public abstract class Component
    {
        public static implicit operator RavenJObject(Component component)
        {
            return component._value;
        }

        protected readonly string _key;
        protected readonly RavenJObject _value;

        public Component(RavenJObject value)
            : this("Name", value)
        {
        }

        public Component(string key, RavenJObject value)
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

        public abstract string Path { get; }

        public override string ToString()
        {
            return _value[_key].ToString();
        }
    }
}
