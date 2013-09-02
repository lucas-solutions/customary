using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Client;
    using Raven.Json.Linq;

    public class Master : IDisposable
    {
        private bool _dispose;
        private IDocumentSession _session;
        private readonly object _lockSession = new object();

        public Master()
        {
            _lockSession = new object();
        }

        internal Master(IDocumentSession session)
        {
            _session = session;
            _dispose = false;
        }

        internal IDocumentSession Session
        {
            get
            {
                var session = _session;

                if (session == null)
                {
                    lock (_lockSession)
                    {
                        session = _session;

                        if (session == null)
                        {
                            _session = session = DocumentStoreHolder.Store.OpenSession();
                            _dispose = true;
                        }
                    }
                }

                return session;
            }
        }

        public Application Application(string host)
        {
            var data = Session.Advanced.LuceneQuery<RavenJObject>("ByHost").WhereStartsWith("Id", "Applications/").Where("Host: '" + host + "'").FirstOrDefault();
            return data != null ? new Application(data, this) : null;
        }

        public LookupResult Lookup(Lookup lookup)
        {
            var name = lookup.Path.Pop();

            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();

                if ("Applications".Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                {
                    var application = Session.Advanced.LuceneQuery<RavenJObject>("ByHost").WhereStartsWith("Id", "Applications/").Where("Host: '" + name + "'").FirstOrDefault();
                }

                lookup.Path.Push(name);
                name = segment;
            }

            lookup.Path.Push(name);

            var resource = Application(Masterdata.SiteName);

            if (resource != null)
                return Value(resource.Lookup(lookup), resource);
        }

        public TypeDescriptor Describe(string name)
        {
            return null;
        }

        public void Dispose()
        {
            if (_dispose && _session != null)
            {
                lock (_lockSession)
                {
                    var session = _session;

                    if (session != null)
                    {
                        _session = null;
                        _dispose = false;

                        session.Dispose();
                    }
                }
            }
        }
    }
}
