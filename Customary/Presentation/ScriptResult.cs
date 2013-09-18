using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Custom.Presentation
{
    public class ScriptResult : ActionResult
    {
        private readonly IScriptable _scriptable;
        
        public ScriptResult(IScriptable scriptable)
        {
            _scriptable = scriptable;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context != null)
            {
                var scriptView = _scriptable as ScriptView;
                if (scriptView != null)
                {
                    scriptView.ControllerContext = context;
                }
            }

            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = "text/javascript";

            _scriptable.Write(response.Output);
        }
    }
}