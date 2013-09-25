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

            page.Title = "Metadata - Entity";

            return page;
        }

        //
        // GET: /Metadata/Entity/Create/

        public ActionResult Create()
        {
            return Json(null);
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
            return Json(null);
        }

        //
        // GET: /Metadata/Entity/Form/

        public ActionResult Form()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Entity/Grid/

        public ActionResult Grid()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Entity/Model/

        public ActionResult Model(string id)
        {
            return ScriptView();

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

        public ActionResult Panel()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Entity/Proxy/

        public ActionResult Proxy()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Entity/Read/
        //[HttpGet, HttpOptions]
        public ActionResult Read(int? page, int? start, int? limit, IEnumerable<Sort> sort, string culture)
        {
            var source = EntityRepository.Current.AsQueryable();

            if (start.HasValue)
                source = source.Skip(start.Value);

            if (limit.HasValue)
                source = source.Take(limit.Value);

            if (sort != null)
                source = source.Sort(sort);

            var array = source.Select(o => o.ToJObject()).ToArray();

            var data = new RavenJArray();

            foreach (var item in array)
                data.Add(item);

            return Raven(data);

            /*return new ResultObject
            {
                Success = true,
                Data = source,
                Total = EntityRepository.Current.Count
            };*/
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
            return Json(null);
        }
    }
}
