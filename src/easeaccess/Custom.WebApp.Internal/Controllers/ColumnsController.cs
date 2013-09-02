using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Processes;
    using Custom.Repositories;
    using Custom.Results;

    public class ColumnsController : ReflectionController
    {
        //
        // GET: /Reflection/Properties/GetHtml

        public ViewResult GetHtml(Column column)
        {
            return View(new ColumnViewModel
            {
                Column = column
            });
        }

        //
        // GET: /Reflection/Properties/GetHtmlWidget

        public PartialViewResult GetHtmlWidget(Column column)
        {
            return PartialView(new ColumnViewModel
            {
                Column = column
            });
        }

        //
        // GET: /Reflection/Properties/GetJson

        public JsonResult GetJson(Column column)
        {
            return Json(new Node
            {
                leaf = true,
                name = column.Name,
                raw = column,
                text = column.Name,
                type = "Column"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
