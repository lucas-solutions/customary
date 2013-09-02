using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Extensions;
    using Custom.Models;
    using Custom.Processes;
    using Custom.Transforms;
    using Custom.Utils;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public abstract class ReflectionController : Controller
    {
        private RavenJObject _jObject;
        private readonly Reflection _reflection;

        private JsonRequestBehavior _jsonReqBehavior = JsonRequestBehavior.AllowGet;

        public ReflectionController()
        {
            if (HttpContext != null)
            {
                _reflection = (RequestReflection)HttpContext;
            }
            else
            {
                _reflection = (RequestReflection)System.Web.HttpContext.Current;
            }
        }

        protected Reflection Reflection
        {
            get { return _reflection; }
        }

        protected RavenJToken Data
        {
            get
            {
                return _jObject != null ? _jObject["data"] : null;
            }
        }

        protected RavenJObject BodyJsonObject
        {
            get
            {
                if (string.Equals("GET", Request.HttpMethod, StringComparison.InvariantCultureIgnoreCase))
                    return null;

                if (_jObject != null)
                    return _jObject;

                var stream = this.Request.InputStream;

                if (stream == null)
                    return null;

                if (!stream.CanRead)
                    return null;

                if (stream.CanSeek)
                    stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(json))
                    {
                        json = json.Trim();

                        if (json.StartsWith("{") && json.EndsWith("}"))
                        {
                            _jObject = RavenJObject.Parse(json);
                        }
                    }
                }

                return _jObject;
            }
        }

        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            return base.BeginExecuteCore(callback, state);
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);
        }

        protected override void EndExecuteCore(IAsyncResult asyncResult)
        {
            base.EndExecuteCore(asyncResult);
        }
    }
}
