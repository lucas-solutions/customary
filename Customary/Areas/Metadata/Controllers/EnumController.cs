using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    public class EnumController : Controller
    {
        //
        // GET: /Metadata/Enum/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metadata/Enum/Create/

        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Metadata/Enum/Data/

        public ActionResult Data()
        {
            return View();
        }

        //
        // GET: /Metadata/Enum/Destroy/

        public ActionResult Destroy()
        {
            return View();
        }


        //
        // GET: /Metadata/Enum/Model/

        public ActionResult Model()
        {
            return PartialView();
        }

        //
        // GET: /Metadata/Enum/Panel/

        public ActionResult Panel()
        {
            return PartialView();
        }

        //
        // GET: /Metadata/Enum/Proxy/

        public ActionResult Proxy()
        {
            return PartialView();
        }

        //
        // GET: /Metadata/Enum/Retrive/

        public ActionResult Retrive()
        {
            return PartialView();
        }

        //
        // GET: /Metadata/Enum/Store/

        public ActionResult Store()
        {
            return PartialView();
        }

        //
        // POST: /Metadata/Enum/Update/
        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }
    }
}
