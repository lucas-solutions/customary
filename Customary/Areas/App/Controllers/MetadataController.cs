using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.App.Metadata.Controllers
{
    using Ext = Custom.Presentation.Sencha.Ext;
    using Custom.Models;
    using Custom.Controllers;
    using Custom.Metadata;
    using Custom.Navigation;
    using Custom.Presentation;
    using Custom.Presentation.Sencha.Ext.data;
    using System.IO;

    public class MetadataController : Controller
    {
        //
        // GET: /App/Metadata/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /App/Metadata/Model

        public ActionResult Model(string id)
        {
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
            .Name("App.metadata.Entity")
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
                    .Add(name: "label", type: "string", covert: (object state) =>
                        {
                            var sw = new ScriptWriter();
                            sw.Write("function(inches) {");
                            sw.WriteLine("return Math.round(inches * 2.54);");
                            sw.WriteLine("}");
                            return sw;
                        })
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

            var serializer = builder
                .ToModel()
                .ToSerializer();

            Func<Ext.data.proxy.Proxy, string[]> proxyRender = (Ext.data.proxy.Proxy proxy) =>
                    {
                        return new string[0];
                    };

            serializer
                .Ignore(o => o.PersistenceProperty)
                .Property<Ext.data.proxy.Proxy>(o => o.Proxy, (Ext.data.proxy.Proxy proxy) =>
                {
                    return new string[0];
                });

            return builder.ToModel().Result();

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
        // GET: /App/Metadata/Object

        public ActionResult Object(string id)
        {
            //var model = new FormViewModel();

            return View();
        }

        //
        // GET: /App/Metadata/Store

        public ActionResult Store(string id)
        {
            //var model = new FormViewModel();

            return View();
        }
    }
}
