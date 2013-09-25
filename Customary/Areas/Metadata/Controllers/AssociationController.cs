using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    public class AssociationController : Custom.Controllers.CustomController
    {
        //
        // GET: /Metadata/Association/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metadata/Association/Form

        public ActionResult Form()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Association/Grid

        public ActionResult Grid()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Association/Model

        public ActionResult Model()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Association/Panel

        public ActionResult Panel()
        {
            return ScriptView();
        }

    }
}
