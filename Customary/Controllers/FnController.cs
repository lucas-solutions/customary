using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Ext = Custom.Presentation.Sencha.Ext;
    using Custom.Presentation;

    public class FnController : Custom.Web.Mvc.CustomController
    {
        //
        // GET: /Fn/Viewport

        public ActionResult Viewport(string id)
        {
            var fn = ScriptFunction("~/Views/Sencha/Ext/container/Viewport.cshtml");

            int key;
            Ext.container.Viewport.Events handler;
            if (System.Enum.TryParse<Ext.container.Viewport.Events>(id, out handler))
                fn.Model(handler);
            else if (int.TryParse(id, out key))
                fn.Model(key);
            else
                fn.Model(0);

            fn.Anonimous();

            return fn;
        }

    }
}
