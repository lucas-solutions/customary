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
            return new ScriptView
            {
                ControllerContext = ControllerContext,
                TempData = TempData,
                ViewName = viewName,
                ViewData = ViewData
            };
        }

        protected virtual ScriptResult Script(IScriptable scriptable)
        {
            var view = scriptable as ScriptView;

            if (view != null)
            {
                view.ControllerContext = ControllerContext;
                view.TempData = TempData;
                view.ViewData = ViewData;
            }

            return new ScriptResult(scriptable);
        }
    }
}
