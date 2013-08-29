using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Processes
{
    using Custom.Objects;
    using Custom.Reflection;
    using Raven.Client;
    using Raven.Json.Linq;

    public static class BusinessProcesses
    {
        [ThreadStatic]
        private static IDocumentSession _session;
        private static IDocumentStore _store;

        public static IDocumentSession Session
        {
            get { return _session ?? (_session = Store.OpenSession()); }
        }

        private static IDocumentStore Store
        {
            get { return _store ?? (_store = DocumentStoreHolder.Store); }
        }

        public static BusinessObject Create(EntityDescriptor descriptor)
        {
            var bo = new BusinessObject(new RavenJObject(), descriptor);

            return bo;
        }

        public static void Dispose()
        {
            var session = _session;
            if (session != null)
            {
                _session = null;
                session.Dispose();
            }
        }

        public static BusinessObject Load(string id, string type)
        {
            var descriptor = ReflectionProcesses.Describe(type) as EntityDescriptor;

            return Load(id, descriptor);
        }

        public static BusinessObject Load(string id, EntityDescriptor descriptor)
        {
            if (descriptor == null)
                throw new InvalidOperationException();

            var data = Session.Load<RavenJObject>(id);

            if (data == null)
                throw new InvalidOperationException();

            var bo = new BusinessObject(data, descriptor);

            return bo;
        }

        public static BusinessObject Merge(this BusinessObject bo, params RavenJObject[] sources)
        {
            var target = bo._data;
            var descriptor = bo._descriptor;

            foreach (var source in sources)
            {
            }

            return bo;
        }

        public static void SaveChanges()
        {
            var session = _session;
            if (session != null)
            {
                session.SaveChanges();
            }
        }

        public static void Validate(this BusinessObject bo)
        {
        }
    }
}