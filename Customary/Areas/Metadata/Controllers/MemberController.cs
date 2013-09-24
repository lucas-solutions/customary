using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Metadata/Member/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metadata/Member/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Metadata/Member/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Metadata/Member/Create

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
        // GET: /Metadata/Member/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Metadata/Member/Edit/5

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
        // GET: /Metadata/Member/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Metadata/Member/Delete/5

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
