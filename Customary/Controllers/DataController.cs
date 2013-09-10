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
        // GET: /Data/{type}/Details/{id}

        public ActionResult Details(string type, int id)
        {
            return View();
        }

        //
        // GET: /Data/{type}/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Data/{type}/Create

        [HttpPost]
        public ActionResult Create(string type, FormCollection collection)
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
        // GET: /Data/{type}/Edit/{id}

        public ActionResult Edit(string type, int id)
        {
            return View();
        }

        //
        // POST: /Data/{type}/Edit/{id}

        [HttpPost]
        public ActionResult Edit(string type, int id, FormCollection collection)
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
        // GET: /Data/{type}/Delete/{id}

        public ActionResult Delete(string type, int id)
        {
            return View();
        }

        //
        // POST: /Data/{type}/Delete/{id}

        [HttpPost]
        public ActionResult Delete(string type, int id, FormCollection collection)
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
