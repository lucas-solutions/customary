using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.App.Metadata.Controllers
{
    using Custom.Models;
    using Custom.Controllers;
    using Custom.Metadata;
    using Custom.Navigation;
    using Custom.Presentation;
    using Custom.Presentation.Sencha.ExtJs;

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

            var vm = new ModelScriptBuilder()
            .Name("App.metadata.Entity")
            .Extend("App.metadata.Complex")
            .Proxy(proxy =>
            {
            })
            .Fields(fields =>
            {
                fields.Add(new FieldScriptBuilder().Name("id").Type("string"));
                fields.Add(new FieldScriptBuilder().Name("name").Type("string"));
                fields.Add(new FieldScriptBuilder().Name("extends").Type("string"));
                fields.Add(new FieldScriptBuilder().Name("identity").Type("string"));
                fields.Add(new FieldScriptBuilder().Name("label").Type("string"));
            })
            .Associations(associations =>
            {
                associations.Add(new AssociationScriptBuilder().HasMany("App.metadata.Field"));
                associations.Add(new AssociationScriptBuilder().HasMany("App.metadata.Association"));
                associations.Add(new AssociationScriptBuilder().HasMany("App.metadata.Validation"));
                associations.Add(new AssociationScriptBuilder().HasMany("App.metadata.Proxy"));
            })
            .Validations(validations =>
            {
                validations.Add(new ValidationScriptBuilder().Presence(""));
                validations.Add(new ValidationScriptBuilder().Length(50));
                validations.Add(new ValidationScriptBuilder().Format(""));
            });

            return vm.Result();

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
