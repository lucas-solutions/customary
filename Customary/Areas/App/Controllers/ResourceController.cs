using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.App.Controllers
{
    using Presentation;

    public class ResourceController : Controller
    {
        // returns pages, views, forms, etc;

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
