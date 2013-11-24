using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Results
{
    using global::Raven.Json.Linq;
    using global::Raven.Imports.Newtonsoft.Json;

    public class RavenResult : ActionResult
    {
        protected virtual string ContentType
        {
            get { return "text/javascript"; }
        }

        public RavenJToken Data
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public bool Success
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = ContentType;

            var result = new RavenJObject();
            result.Add("success", new RavenJValue(Success));
            result.Add("message", new RavenJValue(Message));
            result.Add("data", Data);

            using (var jsonWriter = new JsonTextWriter(response.Output))
            {
                jsonWriter.Formatting = Formatting.Indented;
                result.WriteTo(jsonWriter);
            }
        }
    }
}