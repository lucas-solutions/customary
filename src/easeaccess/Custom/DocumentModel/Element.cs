using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.DocumentModel
{
    using Custom.ComponentModel;
    using Raven.Json.Linq;

    public class Element
    {
        internal readonly RavenJObject _object;
        internal readonly Collection _collection;

        public Element(RavenJObject o, ITypeDescriptor descriptor, Collection collection)
        {
            _object = o;
            _collection = collection;
        }

        public Collection Collection
        {
            get { return _collection; }
        }
    }
}