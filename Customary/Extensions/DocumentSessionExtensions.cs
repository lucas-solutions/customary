using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Raven.Client;
    using Raven.Client.Indexes;
    using Raven.Json.Linq;

    public static class DocumentSessionExtensions
    {
        public static IDocumentQuery<RavenJObject> Query(this IDocumentSession session, string tagName)
        {
            return Query<RavenJObject>(session, tagName);
        }

        public static IDocumentQuery<T> Query<T>(this IDocumentSession session, string tagName)
        {
            return session.Advanced
                .LuceneQuery<T, RavenDocumentsByEntityName>()
                .WhereEquals("Tag", tagName);
        }
    }
}