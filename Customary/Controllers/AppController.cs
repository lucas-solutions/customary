using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    /// <summary>
    /// ExtJs App Controller
    /// </summary>
    public class AppController : Controller
    {
        //
        // GET: /App/data/id

        public JsonResult Data(string id)
        {
            object data = null;

            switch (id.Trim().ToLower())
            {
                case "navigation":
                    data = new object();
                    break;

                default:
                    data = null;
                    break;
            }

            return Json(data);
        }

        //
        // GET: /App/form/id

        public ActionResult Form(string id)
        {
            return PartialView();
        }

        //
        // GET: /App/grid/id

        public PartialViewResult Grid(string id)
        {
            return PartialView();
        }

        //
        // GET: /App/list/id

        public JsonResult List(string id)
        {
            return Json(new object());
        }

        //
        // GET: /App/model/id

        public PartialViewResult Model(string id)
        {
            object model = null;

            switch (id.Trim().ToLower())
            {
                case "navigation":
                    break;

                default:
                    model = null;
                    break;
            }

            return PartialView(model);
        }

        //
        // GET: /App/panel/id

        public PartialViewResult Panel(string id)
        {
            return PartialView();
        }

        //
        // GET: /App/store/id

        public PartialViewResult Store(string id)
        {
            object model = null;

            switch (id.Trim().ToLower())
            {
                case "navigation":
                    break;

                default:
                    model = null;
                    break;
            }

            return PartialView(model);
        }
    }
}
