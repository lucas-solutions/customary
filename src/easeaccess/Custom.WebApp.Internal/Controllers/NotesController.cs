using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Processes;
    using Custom.Repositories;
    using Custom.Results;

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
            return Json(new Node
            {
                leaf = true,
                name = note.Name,
                raw = note,
                text = note.Name,
                type = "Note",
                children = note.Children()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Notes/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(Note note)
        {
            return Json(note.Children(), JsonRequestBehavior.AllowGet);
        }
    }
}
