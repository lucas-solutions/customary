using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Web.Mvc;
    using global::Raven.Json.Linq;

    public class TypeController : NameController
    {
        // Data/Metadata/Type/{category}/{id}/{action}
        // Data/Metadata/Type/{category}/{action}

        private ModelDescriptor _model;

        public ModelDescriptor ResolveModel(string name)
        {
            return _model ?? (_model = DataDictionary.Current.Describe(name) as ModelDescriptor);
        }

        protected TypeDescriptor ResolveType(TypeCategories category, Guid id)
        {
            var name = ModelDescriptor.Dictionary[id];

            if (name == null)
            {
                var definitionKey = "Type/" + System.Enum.GetName(typeof(TypeCategories), category) + "/" + id.ToString("D");
                var definition = Global.Metadata.Session.Load<RavenJObject>(definitionKey);
                if (definition != null)
                    name = definition.Value<string>("name");
            }

            if (name == null)
                return null;

            var descriptior = DataDictionary.Current.Describe(name) as TypeDescriptor;

            return descriptior;
        }

        //
        // GET: Data/Metadata/Type/{category}
        // GET: Data/Metadata/Type/{category}/{Select|Read}
        // GET: Data/Metadata/Type/{category}/{id}
        // GET: Data/Metadata/Type/{category}/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(string category, Guid id, int? skip, int? take)
        {
            TypeCategories cat;
            System.Enum.TryParse<TypeCategories>(category, true, out cat);

            var name = "Metadata/" + System.Enum.GetName(typeof(TypeCategories), cat);

            return base.Select(name, id);
        }

        //
        // POST: Data/Metadata/Type/{category}
        // POST: Data/Metadata/Type/{category}/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string category, Guid type)
        {
            TypeCategories cat;
            System.Enum.TryParse<TypeCategories>(category, true, out cat);

            var name = "Metadata/" + System.Enum.GetName(typeof(TypeCategories), category);
            var descriptor = ResolveModel("Metadata/" + System.Enum.GetName(typeof(TypeCategories), category));

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve model {0}", type) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve model {0} (1) repository", descriptor.Path, type) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Create(new RavenJObject()) };
            }
        }

        //
        // PUT: Data/Metadata/Type/{category}/{id}
        // PUT: Data/Metadata/Type/{category}/{id}/Update
        // PATCH: Data/Metadata/Type/{category}/{id}
        // PATCH: Data/Metadata/Type/{category}/{id}/Update
        // POST: Data/Metadata/Type/{category}/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(string category, Guid id, bool patch)
        {
            //var definition = InputRavenJObject.Deserialize<TypeDefinition>();
            TypeCategories cat;
            System.Enum.TryParse<TypeCategories>(category, true, out cat);

            var name = "Metadata/" + System.Enum.GetName(typeof(TypeCategories), category);
            var descriptor = ResolveModel(name);

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Update(id, null, patch) };
            }
        }

        //
        // DELETE: Data/Metadata/Type/{category}/{id}
        // DELETE: Data/Metadata/Type/{category}/{id}/{Delete|Destroy}
        // GET: Data/Metadata/Type/{category}/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(string category, Guid id)
        {
            TypeCategories cat;
            System.Enum.TryParse<TypeCategories>(category, true, out cat);

            var name = "Metadata/" + System.Enum.GetName(typeof(TypeCategories), category);
            var descriptor = ResolveModel("Metadata/" + System.Enum.GetName(typeof(TypeCategories), category));

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Delete(id) };
            }
        }
    }
}
