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

        protected internal ScriptResultOld Script(object model)
        {
            return this.Script((string)null, model);
        }

        protected internal virtual ScriptResultOld Script(IView view, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptResultOld { View = view, TempData = base.TempData };
        }

        protected internal virtual ScriptResultOld Script(string viewName, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptResultOld { ViewName = viewName, TempData = base.TempData, ViewEngineCollection = this.ViewEngineCollection };
        }
    }
}
