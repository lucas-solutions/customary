using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models.Ext;
    using Custom.Presentation;

    public class FnController : ScriptController
    {
        //
        // GET: /Fn/Viewport

        public ActionResult Viewport(string id)
        {
            var fn = new ScriptFunction();

            var view = CreateScriptView("~/Views/Shared/ViewportHandlers.cshtml");

            int key;
            ViewportHandlers handler;
            if (Enum.TryParse<ViewportHandlers>(id, out handler))
            {
                view.Model = handler;
                view.ViewName = typeof(ViewportHandlers).Name;
            }
            else if (int.TryParse(id, out key))
                view.Model = key;
            else
                view.Model = 0;

            fn.Override(view.NakedFn);

            return Script(fn);
        }

    }
}
