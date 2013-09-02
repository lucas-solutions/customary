using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

    public class NotesController : ReflectionController
    {
        //
        // GET: /Reflection/Notes/GetHtml
        [HttpGet]
        public ViewResult GetHtml()
        {
            return View("Display", new NoteViewModel
            {
                Note = Reflection.Note
            });
        }

        //
        // GET: /Reflection/Notes/GetHtmlWidget
        [HttpGet]
        public PartialViewResult GetHtmlWidget(Note note)
        {
            return PartialView("Display", new NoteViewModel
            {
                Note = note
            });
        }

        //
        // GET: /Reflection/Notes/GetJson
        [HttpGet]
        public JsonResult GetJson(Note note)
        {
            return Json(new NoteViewModel
            {
                Note = note
            });
        }
    }
}
