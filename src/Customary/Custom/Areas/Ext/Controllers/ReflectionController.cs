﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Ext.Controllers
{
    public class ReflectionController : Controller
    {
        //
        // GET: /Ext/Reflection/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create()
        {
            return Json(null);
        }

        [HttpGet]
        public JsonResult Read()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update()
        {
            return Json(null);
        }

        [HttpPost]
        public JsonResult Destroy()
        {
            return Json(null);
        }

    }
}
