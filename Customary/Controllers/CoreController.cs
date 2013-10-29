using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class CoreController : Custom.Web.Mvc.CustomController
    {
        public ActionResult Adapter()
        {
            return ScriptView();
        }

        public ActionResult Text()
        {
            return ScriptView();
        }
        //
        // GET: /Core/TextArea

        public ActionResult TextArea()
        {
            return ScriptView();
        }

        //
        // GET: /Core/TextField

        public ActionResult TextField()
        {
            return ScriptView();
        }
    }
}
