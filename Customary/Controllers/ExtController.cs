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

        // GET: Scripts/Ext/custom/Factory.js

        public ActionResult Factory()
        {
            return ScriptView();
        }
    }
}
