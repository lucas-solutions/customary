using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    using Custom.Areas.Metadata.Models;
    using Custom.Controllers;
    using Custom.Models;
    using Custom.Metadata;
    using Custom.Navigation;
    using Custom.Presentation;
    using Custom.Presentation.Sencha.Ext.data;
    using Ext = Custom.Presentation.Sencha.Ext;
    using Raven.Json.Linq;

    public class EntityController : Custom.Controllers.CustomController
    {
        //
        // GET: /Metadata/Entity

        public ActionResult Index()
        {
            var entity = new Entity();

            var page = this.Page(entity);

            page.Title = "Welcome to Customary Metadata";

            return page;
        }

        //
        // GET: /Metadata/Entity/Create/

        public ActionResult Create()
        {
            var annotations = new List<Annotation>();
            var descriptor = Global.Metadata.Describe("Custom.Metadata.Entity") as EntityDescriptor;
            var record = Custom.Global.Metadata.Create(Data, descriptor, annotations);

            Custom.Global.Metadata.Session.SaveChanges();

            return Raven(true, string.Join("\n", annotations), record);
        }

        //
        // GET: /Metadata/Entity/Details/5

        public ActionResult Details(int id)
        {
            return Json(null);
        }

        //
        // GET: /Metadata/Entity/Destroy/

        public ActionResult Destroy()
        {
            var annotations = new List<Annotation>();
            var descriptor = Global.Metadata.Describe("Custom.Metadata.Entity") as EntityDescriptor;
            var record = Custom.Global.Metadata.Destroy(Data, descriptor, annotations);

            Custom.Global.Metadata.Session.SaveChanges();

            return Raven(true, string.Join("\n", annotations), record);
        }

        //
        // GET: /Metadata/Property/Editor/

        public ActionResult Editor(string id)
        {
            if (string.IsNullOrEmpty(id))
                return ScriptView();

            var descriptor = Global.Metadata.Session.Load<EntityDescriptor>("Type/Entity/" + id);

            var storeName = descriptor.GetStoreName();

            var model = new Presentation.Sencha.Ext.grid.Panel(descriptor);

            var builder = model.ToBuilder();

            return ScriptView("~/Areas/Metadata/Views/Shared/Editor.cshtml", model);
        }

        //
        // GET: /Metadata/Entity/Model/

        public ActionResult Model(string id)
        {
            if (string.IsNullOrEmpty(id))
                return ScriptView();

            var descriptor = Global.Metadata.Session.Load<EntityDescriptor>("Type/Entity/" + id);

            return ScriptView(descriptor);

            Guid identity;

            if (id == null)
            {
                id = "Entity";
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
            .Define("App.metadata.Entity")
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

            if (type.MemberType != Metadata.MemberTypes.Entity)
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
        // GET: /Metadata/Entity/Panel/

        public ActionResult Panel(string id)
        {
            if (string.IsNullOrEmpty(id))
                return ScriptView();

            var descriptor = Global.Metadata.Session.Load<EntityDescriptor>("Type/Entity/" + id);

            return ScriptView(descriptor);
        }

        //
        // GET: /Metadata/Entity/Read/
        //[HttpGet, HttpOptions]
        public ActionResult Read(int? page, int? start, int? limit, IEnumerable<Sort> sort, string culture)
        {
            var annotations = new List<Annotation>();

            //var entityDescriptor = Global.Metadata.Describe("Custom.Metadata.Entity") as EntityDescriptor;

            //var tagName = entityDescriptor.StoreName();

            var result = Global.Metadata.Store.Read("Type/Entity", start ?? 0, limit ?? 400);

            return Raven(true, string.Join("\n", annotations), result.ToRavenJArray());
        }

        //
        // GET: /Metadata/Entity/Store/

        public ActionResult Store()
        {
            return ScriptView();
        }

        //
        // POST: /Metadata/Entity/Update/
        [HttpPost]
        public ActionResult Update()
        {
            var annotations = new List<Annotation>();
            var descriptor = Global.Metadata.Describe("Custom.Metadata.Entity") as EntityDescriptor;
            var record = Custom.Global.Metadata.Update(Data, descriptor, annotations);

            Custom.Global.Metadata.Session.SaveChanges();

            return Raven(true, string.Join("\n", annotations), record);
        }
    }
}
