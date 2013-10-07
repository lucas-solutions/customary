using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    public class ComplexController : Custom.Controllers.CustomController
    {
        //
        // GET: /Metadata/Complex/

        public ActionResult Index()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Complex/Editor

        public ActionResult Editor(string id)
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Complex/Picker

        public ActionResult Picker(string id)
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Complex/Viewer

        public ActionResult Viewer(string id)
        {
            return ScriptView();
        }

    }
}
