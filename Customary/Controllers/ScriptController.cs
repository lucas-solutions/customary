using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Presentation;

    public class ScriptController : Controller
    {
        //
        // GET: /Script/

        public ActionResult Index()
        {
            return View();
        }

        protected virtual ScriptView CreateScriptView(string viewName)
        {
            var view = new ScriptView
            {
                ViewName = viewName
            };

            var serializer = view;
            serializer.ControllerContext = ControllerContext;
            serializer.TempData = TempData;
            serializer.ViewData = ViewData;

            return view;
        }

        protected virtual ScriptView CreateScriptView(string viewName, object model)
        {
            var view = new ScriptView
            {
                Model = model,
                ViewName = viewName
            };
            
            var serializer = view;
            serializer.ControllerContext = ControllerContext;
            serializer.TempData = TempData;
            serializer.ViewData = ViewData;

            return view;
        }

        protected virtual ScriptResult Script(IScriptable scriptable)
        {
            var view = scriptable as ScriptView;

            if (view != null)
            {
                var serializer = view;
                serializer.ControllerContext = ControllerContext;
                serializer.TempData = TempData;
                serializer.ViewData = ViewData;
            };

            return new ScriptResult(scriptable);
        }
    }
}
