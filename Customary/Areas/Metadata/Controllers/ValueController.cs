using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    public class ValueController : Custom.Controllers.CustomController
    {
        //
        // GET: /Metadata/Value/

        public ActionResult Index()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Value/Editor

        public ActionResult Editor(string id)
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Value/Picker

        public ActionResult Picker(string id)
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Value/Viewer

        public ActionResult Viewer(string id)
        {
            return ScriptView();
        }

    }
}
