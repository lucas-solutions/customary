using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Results;

    public class ResourcesController : Controller
    {
        protected internal ScriptResult Script(object model)
        {
            return this.Script((string)null, model);
        }

        protected internal virtual ScriptResult Script(IView view, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptResult { View = view, TempData = base.TempData };
        }

        protected internal virtual ScriptResult Script(string viewName, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = model;
            }
            return new ScriptResult { ViewName = viewName, TempData = base.TempData, ViewEngineCollection = this.ViewEngineCollection };
        }
    }
}
