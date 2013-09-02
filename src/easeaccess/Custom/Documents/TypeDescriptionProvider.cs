using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Client;

    public abstract class TypeDescriptionProvider : IDisposable
    {
        private bool _dispose;
        private IDocumentSession _session;
        private readonly object _lockSession = new object();

        public TypeDescriptionProvider()
        {
            _lockSession = new object();
        }

        internal TypeDescriptionProvider(IDocumentSession session)
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
