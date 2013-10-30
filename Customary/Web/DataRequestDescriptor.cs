using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Data.Serialization;

    public class DataRequestDescriptor : RequestDescriptor
    {
        const string idProp = "Id";

        public static DataRequestDescriptor Parse(string[] tokens)
        {
            return null;
        }

        private Guid? _id;
        private DataRequestVerb _verb;

        public DataRequestDescriptor(RequestContext requestContext, string controllerName)
            : base(requestContext, controllerName)
        {

        }

        public Guid? Id
        {
            get { return _id; }
        }

        public DataRequestVerb Verb
        {
            get { return _verb; }
        }

        protected override void Initialize()
        {
            var directory = Global.Directory;

            var request = RequestContext.HttpContext.Request;

            var path = request.Path;

            Queue<string> surplus = null;

            var match = string.IsNullOrEmpty(path) ? directory : directory.Match(path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).AsEnumerable().GetEnumerator(), out surplus);

            if (match == null)
                return;
            
            var method = request.HttpMethod.ToUpperInvariant();

            Guid id;
            if (surplus != null && surplus.Count > 0 && Guid.TryParse(surplus.Peek(), out id))
            {
                _id = id;
                RequestContext.RouteData.Values[idProp] = surplus.Dequeue();
            }

            if (surplus != null)
            {
                switch (surplus.Count)
                {
                    case 0:
                        break;

                    case 1:
                        var verb = new DataRequestVerb(surplus.Peek());
                        if (!verb.Valid)
                            return;
                        _verb = verb;
                        break;

                    default:
                        return;
                }
            }

            var acceptFormats = request.AcceptTypes.Select(o => new StreamFormat(o)).ToArray();

            if (acceptFormats.Any(o => o.Equals(StreamFormat.Application.JavaScript)))
            {
            }
            else if (acceptFormats.Any(o => o.Equals(StreamFormat.Application.Json)))
            {
            }
            else if (acceptFormats.Any(o => o.Equals(StreamFormat.Any)))
            {
            }
            else
            {
            }

            switch (method)
            {
                case "GET":
                    if (_verb == null)
                    {
                        if (acceptFormats.Any(StreamFormat.Application.Json))
                            Match(_verb = DataRequestVerb.Read, match);
                        else if (acceptFormats.Any(StreamFormat.Text.Html, StreamFormat.Any))
                            Match(_verb = DataRequestVerb.Browse, match);
                    }
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                case "POST":
                    if (_verb == null)
                    {
                        // TODO: entity or service?
                        Match(_verb = DataRequestVerb.Update, match);
                    }
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                case "DELETE":
                    if (_verb == null)
                        Match(_verb = DataRequestVerb.Delete, match);
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                case "PUT":
                    if (_verb == null)
                        Match(_verb = DataRequestVerb.Create, match);
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                case "PATCH":
                    if (_verb == null)
                        Match(_verb = DataRequestVerb.Update, match);
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                case "OPTIONS":
                    if (_verb == null)
                        Match(_verb = DataRequestVerb.Options, match);
                    else if (_verb.Accepts(method))
                        Match(_verb, match);
                    break;

                default:
                    Match(DataRequestVerb.Browse, match);
                    break;
            }
        }

        private void Match(DataRequestVerb verb, Directory directory)
        {
            ControllerType = typeof(Custom.Controllers.DataController);
            ControllerName = "Data";
            Action = verb;
            
            if (directory.Key != null)
            {
                RequestContext.RouteData.Values["key"] = directory.Key;
                RequestContext.RouteData.Values["id"] = directory.Id;
            }

            RequestContext.RouteData.Values["name"] = directory.Name;
            RequestContext.RouteData.Values["path"] = directory.Path;
            RequestContext.RouteData.Values["directory"] = directory;
        }
    }
}