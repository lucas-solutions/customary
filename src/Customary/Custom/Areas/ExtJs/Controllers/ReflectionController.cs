using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.ExtJs.Controllers
{
    using Custom.Areas.ExtJs;
    using Custom.Reflection;

    public class ReflectionController : Controller
    {
        //
        // GET: /ExtJs/Reflection/

        public ActionResult GetScriptModel()
        {
            var model = Custom.Objects.DocumentStoreHolder.Types.OfType<ComplexDescriptor>().SingleOrDefault(o => o.Name == "SalesDocument").ExtModel();
            return View(model);
        }

    }
}
