﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class ExamplesController : Controller
    {
        //
        // GET: /Examples/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reflection()
        {
            return View();
        }
    } 
}
