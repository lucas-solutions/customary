using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Web.Mvc
{
    using global::Raven.Imports.Newtonsoft.Json;
    using global::Raven.Json.Linq;

    public class RavenJObjectResult : ActionResult
    {
        private string _contentType;

        public RavenJObject Content
        {
            get;
            set;
        }

        protected virtual string ContentType
        {
            get { return _contentType ?? "application/json"; }
            set { _contentType = value; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = ContentType;

            var content = Content;
            
            if (content != null)
            {
                using (var jsonWriter = new JsonTextWriter(response.Output))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    content.WriteTo(jsonWriter);
                }
            }
        }
    }
}