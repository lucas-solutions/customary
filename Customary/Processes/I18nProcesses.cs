using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Custom.Processes
{
    using Custom.Objects;
    using Raven.Client;

    public static class I18nProcesses
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

        public static string CurrentValue(this TextObject text)
        {
            string value = text.Values.FirstOrDefault();
            var culture = Thread.CurrentThread.CurrentCulture;
            for (var i = 0; i < text.Count && culture.Name != ""; culture = culture.Parent)
            {
                if (text.TryGetValue(culture.Name, out value))
                    break;
            }
            return value;
        }
    }
}