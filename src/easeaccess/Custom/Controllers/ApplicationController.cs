﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Children()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
