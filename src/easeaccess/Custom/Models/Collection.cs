using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Raven.Json.Linq;

    public class Collection : IEnumerable
    {
        private readonly string _k;
        protected readonly IModel _m;
        protected readonly Document _d;
        protected readonly RavenJArray _a;

        public Collection(string k, IModel m, Document d)
        {
            _k = k;
            _a = d.Array(k);
            _m = m;
            _d = d;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _a.OfType<RavenJObject>().Select(o => new Element(o, this)).GetEnumerator();
        }
    }

    public class Collection<TElement> : Collection, IEnumerable<TElement>
        where TElement : Element
    {
        public Collection(string k, IModel m, Document d)
            : base(k, m, d)
        {
        }

        public void Insert(int index, RavenJToken t)
        {
        }

        IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
        {
            return _a.OfType<RavenJObject>().Select(o => (TElement)Activator.CreateInstance(typeof(TElement), new object[] { o, this })).GetEnumerator();
        }
    }
}