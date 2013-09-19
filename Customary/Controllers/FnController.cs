using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Ext = Custom.Presentation.Sencha.Ext;
    using Custom.Presentation;

    public class FnController : ScriptController
    {
        //
        // GET: /Fn/Viewport

        public ActionResult Viewport(string id)
        {
            var fn = new ScriptFunction();

            var view = CreateScriptView("~/Views/Sencha/Ext/container/Viewport.cshtml");

            int key;
            Ext.container.Viewport.Events handler;
            if (Enum.TryParse<Ext.container.Viewport.Events>(id, out handler))
            {
                view.Model = handler;
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
