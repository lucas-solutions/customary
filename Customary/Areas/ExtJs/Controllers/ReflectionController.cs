using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.ExtJs.Controllers
{
    using Custom.Areas.ExtJs;
    using Custom.Metadata;

    public class ReflectionController : Controller
    {
        //
        // GET: /ExtJs/Reflection/

        public ActionResult GetScriptModel()
        {
            var model = Global.Metadata.Types.OfType<ComplexDescriptor>().SingleOrDefault(o => o.Name == "SalesDocument").ExtModel();
            return View(model);
        }

    }
}
