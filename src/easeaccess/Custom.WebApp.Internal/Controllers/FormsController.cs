using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Exceptions;
    using Custom.Models;
    using Custom.Processes;
    using Custom.Repositories;
    using Custom.Results;

    public class FormsController : ReflectionController
    {
        //
        // GET: /Reflection/Forms/GetHtml

        [HttpGet]
        public ViewResult GetHtml(Model record)
        {
            return View(new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Forms/GetHtmlWidget

        [HttpGet]
        public PartialViewResult GetHtmlWidget(Model record)
        {
            return PartialView(new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Forms/GetJson
        [HttpGet]
        public JsonResult GetJson(Model form)
        {
            return Json(new Node
            {
                name = form.Name,
                raw = form,
                text = form.Name,
                type = "Form",
                children = form.Children()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Forms/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(Model form)
        {
            return Json(form.Children(), JsonRequestBehavior.AllowGet);
        }

        //
        // OPTIONS: /Reflection/Forms/Options

        [HttpOptions]
        public ActionResult Options(Model record)
        {
            return View(new FormViewModel
            {
                Form = record
            });
        }

        //
        // PATCH: /Reflection/Forms/PatchJson

        [HttpPatch]
        public JsonResult PatchJson(Model record)
        {
            return Json(new FormViewModel
            {
                Form = record
            });
        }

        //
        // PUT: /Reflection/Forms/PostJson

        [HttpPost]
        public ActionResult PostJson(Model form)
        {
            return View(new FormViewModel
            {
                Form = form
            });
        }

        //
        // POST: /Reflection/Forms/PutJson
        
        [HttpPut]
        public JsonResult PutJson(Model with)
        {
            return Json(new FormViewModel
            {
                Form = Reflection.Form
            });
        }

        #region - Fields -

        //
        // GET: /Reflection/Forms/GetFieldsHtml
        [HttpGet]
        public ViewResult GetFieldsHtml(Model record)
        {
            return View("DisplayFields", new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Forms/GetFieldsHtmlWidget
        [HttpGet]
        public PartialViewResult GetFieldsHtmlWidget(Model record)
        {
            return PartialView("DisplayFields", new FormViewModel
            {
                Form = record
            });
        }

        //
        // GET: /Reflection/Forms/GetFieldsJson
        [HttpGet]
        public JsonResult GetFieldsJson(Model form)
        {
            return Json(new Node
            {
                name = form.Name,
                raw = form,
                text = form.Name,
                type = "Fields",
                children = form.FieldsChildren()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Forms/GetFieldsJsonChildren
        [HttpGet]
        public JsonResult GetFieldsJsonChildren(Model form)
        {
            return Json(form.FieldsChildren(), JsonRequestBehavior.AllowGet);
        }

        #endregion - Fields -
    }
}
