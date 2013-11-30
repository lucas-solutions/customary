using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Navigation
{
    using global::Raven.Json.Linq;

    public static class NavigationExtensions
    {
        public static PathLookup Lookup(this Data.Persistence.NavigationContext ctx, Uri url)
        {
            var lookup = new PathLookup(url);

            var name = lookup.Path.Pop();

            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();

                if ("Applications".Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                {
                    using (var session = ctx.Store.OpenSession())
                    {
                        var application = session.Advanced.LuceneQuery<RavenJObject>("ByHost").WhereStartsWith("Id", "Applications/").Where("Host: '" + name + "'").FirstOrDefault();
                    }
                }

                lookup.Path.Push(name);
                name = segment;
            }

            lookup.Path.Push(name);

            /*var resource = Application(Masterdata.SiteName);

            if (resource != null)
                return Value(resource.Lookup(lookup), resource);*/

            return lookup;
        }
    }
}