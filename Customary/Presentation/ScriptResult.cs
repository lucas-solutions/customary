using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Custom.Presentation
{
    public class ScriptResult : ActionResult
    {
        ScriptBuilder _builder;

        public ScriptResult(ScriptBuilder builder)
        {
            _builder = builder;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var writer = new ScriptWriter(context.HttpContext.Response.Output);

            _builder.Write(writer);

            context.RequestContext.HttpContext.Response.ContentType = "text/javascript";
        }
    }
}