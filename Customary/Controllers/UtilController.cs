using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class UtilController : CustomController
    {
        public ActionResult Adapter()
        {
            return ScriptView();
        }
    }
}
