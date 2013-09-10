using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Presentation;

    public abstract class CustomController : Controller
    {
        static readonly string[] Framework = new[] {
            "JQuery",
            "IE",
            "Mobile",
            "Knockout",
            "AngularJs",
            "ExtJs"
        };

        protected internal virtual PageResult Page(string viewName, string layout, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = new PageModel
                    {
                        Title = ViewBag.Title,
                        Main = viewName,
                    };
            }
            return new PageResult { ViewName = viewName, TempData = base.TempData, ViewEngineCollection = this.ViewEngineCollection };
        }

        protected internal ScriptViewResult Script(object model)
        {
            return this.Script((string)null, model);
        }

        protected internal virtual ScriptViewResult Script(IView view, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptViewResult { View = view, TempData = base.TempData };
        }

        protected internal virtual ScriptViewResult Script(string viewName, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptViewResult { ViewName = viewName, TempData = base.TempData, ViewEngineCollection = this.ViewEngineCollection };
        }
    }
}
