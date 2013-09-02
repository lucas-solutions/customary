using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Objects;
    using Raven.Client;

    public class Masterdata : IDisposable
    {
        private IDocumentSession _session;

        public IQueryable<Object> Apps
        {
            get { return Session.Query<ApplicationObject>(); }
        }

        private IDocumentSession Session
        {
            get { return _session ?? (_session = Documents.DocumentStoreHolder.Store.OpenSession()); }
        }

        public void Dispose()
        {
            var session = _session;
            if (session != null)
            {
                _session = null;
                session.Dispose();
            }
        }
    }
}
