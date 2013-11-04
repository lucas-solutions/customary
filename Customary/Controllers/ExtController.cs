using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Web.Mvc;

    public class ExtController : CustomController
    {
        // GET: Scripts/Ext/custom/Adapter.js

        public ActionResult Adapter()
        {
            return ScriptView();
        }
    }
}
