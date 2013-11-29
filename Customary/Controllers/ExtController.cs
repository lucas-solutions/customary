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

        // GET: Scripts/Ext/custom/Application.js

        public ActionResult Application()
        {
            return ScriptView();
        }

        // GET: Scripts/Ext/custom/Directory.js

        public ActionResult Directory()
        {
            return ScriptView();
        }

        // GET: Scripts/Ext/custom/Droplet.js

        public ActionResult Droplet()
        {
            return ScriptView();
        }

        // GET: Styles/Ext.css?theme={theme}

        public ActionResult Style(string theme)
        {
            switch ((theme ?? string.Empty).ToLowerInvariant())
            {
                case "access":
                    return File("~/Styles/ext/ext-theme-access/ext-theme-access-all.css", "text/css");

                case "gray":
                    return File("~/Styles/ext/ext-theme-gray/ext-theme-gray-all.css", "text/css");

                case "neptune":
                    return File("~/Styles/ext/ext-theme-neptune/ext-theme-neptune-all.css", "text/css");

                case "classic":
                default:
                    return File("~/Styles/ext/ext-theme-classic/ext-theme-classic-all.css", "text/css");
            }
        }
    }
}
