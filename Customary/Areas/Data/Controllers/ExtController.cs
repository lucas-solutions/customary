using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Web.Mvc;

    public class ExtController : CustomController
    {
        //
        // GET: Ext/custom/data/Directory.js

        public ActionResult Directory()
        {
            return ScriptView();
        }

        //
        // GET: Ext/custom/data/Index.js

        public ActionResult Index()
        {
            return ScriptView();
        }
    }
}
