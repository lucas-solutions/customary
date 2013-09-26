using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class CoreController : CustomController
    {
        public ActionResult Adapter()
        {
            return ScriptView();
        }

        public ActionResult Text()
        {
            return ScriptView();
        }
    }
}
