﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    using Custom.Areas.Metadata.Models;
    using Custom.Controllers;
    using Custom.Models;
    using Custom.Data.Metadata;
    using Custom.Web.Mvc;
    using Custom.Site.Presentation;
    using Custom.Site.Presentation.Sencha.Ext.data;
    using Ext = Custom.Site.Presentation.Sencha.Ext;

    public class PropertyController : Custom.Web.Mvc.CustomController
    {
        //
        // GET: /Metadata/Property/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metadata/Property/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Metadata/Property/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Metadata/Property/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Metadata/Property/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Metadata/Property/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Metadata/Property/Editor/

        public ActionResult Editor()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Property/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Metadata/Property/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Metadata/Property/Model/

        public ActionResult Model(string id)
        {
            return ScriptView();

            Guid identity;

            if (id == null)
            {
                id = "Property";
            }
            else if (Guid.TryParse(id, out identity))
            {
            }
            else
            {
            }

            var type = Global.Metadata.Describe(id);

            var builder = new Ext.data.Model.Builder();

            builder
            .Define("App.metadata.Property")
            .Extend("App.metadata.Complex")
            .Proxy(proxy =>
            {
            })
            .Fields(fields =>
            {
                fields
                    .Add(name: "id", type: "string")
                    .Add(name: "name", type: "string")
                    .Add(name: "extends", type: "string")
                    .Add(name: "identity", type: "string")
                    /*.Add(name: "label", type: "string", covert: (object state) =>
                        {
                            var sw = new ScriptWriter();
                            sw.Write("function(inches) {");
                            sw.WriteLine("return Math.round(inches * 2.54);");
                            sw.WriteLine("}");
                            return sw;
                        })*/
                    .Add(name: "proxy", type: "App.metadata.Proxy");
            })
            .Associations(associations =>
            {
                associations
                    .HasMany(name: "Fields", model: "App.metadata.Field")
                    .HasMany(name: "Associations", model: "App.metadata.Association")
                    .HasMany(name: "Validations", model: "App.metadata.Validation");
            })
            .Validations(validations =>
            {
                validations
                    .Presence(field: "name")
                    .Length(field: "Age", min: 50)
                    .Format(field: "name", matcher: @"/([a-z]+)[0-9]{2,3}/");
            });

            Func<Ext.data.proxy.Proxy, string[]> proxyRender = (Ext.data.proxy.Proxy proxy) =>
            {
                return new string[0];
            };

            /*builder
                .Ignore(o => o.PersistenceProperty)
                .Property<ScriptField<Ext.data.proxy.Proxy>>(o => o.Proxy, (lines, proxy) => 
                {
                    if (proxy != null)
                    {
                    }
                });*/

            builder
                .Resource(ScriptFunction("~/Views/Sencha/Ext/container/Viewport.cshtml", Ext.container.Viewport.Events.Click).Strip().TrimLeft())
                .Resource(ScriptFunction("~/Views/Sencha/Ext/container/Viewport.cshtml", Ext.container.Viewport.Events.MouseDown).Strip().TrimLeft())
                .Resource(ScriptFunction("~/Views/Sencha/Ext/container/Viewport.cshtml", Ext.container.Viewport.Events.MouseMove).Anonimous())
                .Resource(ScriptFunction("~/Views/Sencha/Ext/container/Viewport.cshtml", Ext.container.Viewport.Events.MouseUp).Anonimous());

            return builder.ToModel();

            /*var type = Global.Metadata.Describe(id);

            if (type.MemberType != Metadata.MemberTypes.Property)
            {
                return View();
            }

            var accept = Request.Accept();

            if (accept.Test(AcceptTypes.JavaScript))
            {
                var model = new ModelScriptBuilder(null)
                {
                };

                return Script(Scripts.Model, model);
            }

            if (accept.Test(AcceptTypes.Html) || accept == AcceptTypes.Any)
            {
            }*/
        }

        //
        // GET: /Metadata/Property/Proxy/

        public ActionResult Proxy()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Property/Retrive/

        public ActionResult Retrive()
        {
            return Json(null);
        }

        //
        // GET: /Metadata/Property/Store/

        public ActionResult Store()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Property/TypeField

        public ActionResult TypeField()
        {
            return ScriptView();
        }
    }
}
