using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custom.Extensions
{
    using Dictionary = Dictionary<string, object>;
    using Custom.Models;
    using Raven.Client;
    using Custom.Documents;

    public static class HttpRequestExtensions
    {
        public static bool TryGetValue(this HttpRequest httpRequest, out Dictionary value)
        {
            return httpRequest.InputStream.TryGetValue(httpRequest.ContentType, out value);
        }

        public static bool TryGetValue<T>(this HttpRequest httpRequest, out T value)
            where T : new()
        {
            return httpRequest.InputStream.TryGetValue(httpRequest.ContentType, out value);
        }

        public static bool TryHandle(this HttpRequest request)
        {
            var query = request.Params;

            var segments = request
                .Path.ToLower()
                .Split(new[] { "/", "\\" }, StringSplitOptions.RemoveEmptyEntries);

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var enumerator = segments.ToList().GetEnumerator();
                var app = Application(enumerator, session);

                if (app != null)
                {
                    Area area = app;

                    while (area != null && enumerator.Current != null)
                    {
                        var child = area.Areas.SingleOrDefault(o => o.Name == enumerator.Current);

                        if (child == null)
                            break;

                        area = child;

                        enumerator.MoveNext();
                    }
                }
            }

            return false;
        }

        public static App Application(IEnumerator<string> segment, IDocumentSession session)
        {
            var appCount = session
                .Query<App>()
                .Count();

            App app = null;

            switch (appCount)
            {
                case 0:
                    break;

                case 1:
                    app = session.Query<App>().FirstOrDefault();
                    if (app.Id == segment.Current)
                        segment.MoveNext();
                    break;

                default:
                    app = session.Query<App>().Where(o => o.Id == segment.Current).FirstOrDefault();
                    break;
            }

            return app;
        }
    }
}
