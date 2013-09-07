using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Data/{typeID}/Details/{entityID}

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Data/{typeID}/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Data/{typeID}/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Data/{typeID}/Edit/{entityID}

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Data/{typeID}/Edit/{entityID}

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Data/{typeID}/Delete/{entityID}

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Data/{typeID}/Delete/{entityID}

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
