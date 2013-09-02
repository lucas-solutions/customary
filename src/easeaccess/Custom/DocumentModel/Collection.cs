using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.DocumentModel
{
    using Custom.ComponentModel;

    using Raven.Json.Linq;

    public class Collection
    {
        private readonly string _key;
        protected readonly ITypeDescriptor _descriptor;
        protected readonly Document _document;
        protected readonly RavenJArray _array;

        public Collection(string key, ITypeDescriptor descriptor, Document document)
        {
            _key = key;
            _array = document.Array(key);
            _descriptor = descriptor;
            _document = document;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.OfType<RavenJObject>().Select(o => new Element(o, _descriptor, this)).GetEnumerator();
        }
    }
}