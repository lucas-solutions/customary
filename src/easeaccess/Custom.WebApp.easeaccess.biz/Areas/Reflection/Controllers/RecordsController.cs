using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Exceptions;
    using Custom.Processes;
    using Custom.Repositories;

    public class RecordsController : ReflectionController
    {
        //
        // DELETE: /Reflection/Records/DeleteJson
        

        //
        // GET: /Reflection/Records/GetHtml

        [HttpGet]
        public ViewResult GetHtml(Form record)
        {
            return View(new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Records/GetHtmlWidget

        [HttpGet]
        public PartialViewResult GetHtmlWidget(Form record)
        {
            return PartialView(new FormViewModel
            {
                Form = record
            });
        }

        //
        // OPTIONS: /Reflection/Records/Options

        [HttpOptions]
        public ActionResult Options(Form record)
        {
            return View(new FormViewModel
            {
                Form = record
            });
        }

        //
        // PATCH: /Reflection/Records/PatchJson

        [HttpPatch]
        public JsonResult PatchJson(Form record)
        {
            return Json(new FormViewModel
            {
                Form = record
            });
        }

        //
        // PUT: /Reflection/Records/PostJson

        [HttpPost]
        public ActionResult PostJson(Form form)
        {
            return View(new FormViewModel
            {
                Form = form
            });
        }

        //
        // POST: /Reflection/Records/PutJson
        
        [HttpPut]
        public JsonResult PutJson(Form with)
        {
            return Json(new FormViewModel
            {
                Form = Reflection.Form
            });
        }

        #region - Fields -

        //
        // GET: /Reflection/Records/GetFilesHtml
        [HttpGet]
        public ViewResult GetFilesHtml(Form record)
        {
            return View("DisplayFiles", new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Records/GetFilesHtmlWidget
        [HttpGet]
        public PartialViewResult GetFilesHtmlWidget(Form record)
        {
            return PartialView("DisplayFiles", new FormViewModel
            {
                Form = record
            });
        }

        #endregion - Fields -
    }
}
