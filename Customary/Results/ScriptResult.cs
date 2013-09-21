using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Results
{
    using Custom.Presentation;
    using System.IO;

    public abstract class ScriptResult : ActionResult, IScriptable
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = "text/javascript";

            Write(response.Output);
        }

        public abstract void Render(List<string> lines);

        public virtual void Write(TextWriter writer)
        {
            var lines = new List<string>();
            Render(lines);
            writer.WriteAllLines(lines);
        }
    }
}