using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Models;
    using Custom.Web.Mvc;
    using Raven.Json.Linq;
    using System.Web.Routing;

    public class NameController : CustomController
    {
        //
        // GET: data.{domain}/{*name}/{id}

        public ActionResult Default(string name, Guid id)
        {
            return View("~/Areas/Data/Views/Name/Default.cshtml");
        }

        //
        // GET: Data/{*name}/$metadata

        class MetadataRequestExtra
        {
            public string[] Requires { get; set; }
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Metadata(string name)
        {
            const string MissmatchError = "{0} is fully quialified by name. No need to provide id. Where you expecting a model?";
            const string UnexpectedError = "Unexpected error";

            bool success = true;
            string message = null;
            RavenJObject data = null;
            var descriptor = DataDictionary.Current.Describe(name);
            var extra = InputRavenJObject.Deserialize<MetadataRequestExtra>();
            var requires = extra != null ? extra.Requires : new string [] { };

            if (descriptor == null)
            {
                success = false;
                message = "Name not Found";
            }
            else
            {
                switch (descriptor.Type)
                {
                    case NodeKinds.Area:
                        data = descriptor.Metadata(requires);
                        break;

                    case NodeKinds.Error:
                        {
                            success = false;
                            message = (descriptor as ErrorDescriptor).Message;
                        }
                        break;

                    case NodeKinds.Name:
                        data = descriptor.Metadata(requires);
                        break;

                    case NodeKinds.Type:
                        {
                            var type = descriptor as TypeDescriptor;

                            switch (type.Category)
                            {
                                case TypeCategories.Enum:
                                    data = descriptor.Metadata(requires);
                                    break;

                                case TypeCategories.Model:
                                    data = descriptor.Metadata(requires);
                                    break;

                                case TypeCategories.Unit:
                                    data = descriptor.Metadata(requires);
                                    break;

                                case TypeCategories.Value:
                                    data = descriptor.Metadata(requires);
                                    break;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            if (!success)
            {
                if (data == null)
                    data = new RavenJObject();

                data["url"] = new RavenJValue((RouteData.Route as Route).Url);

                foreach (var item in RouteData.Values)
                    data[item.Key] = new RavenJValue(item.Value);

                data["name"] = new RavenJValue(name);

                return Failure(data, message);
            }

            return Success(data);
        }

        //
        // GET: Data/{*name}
        // GET: Data/{*name}/{Select|Read}
        // GET: Data/{*name}/{id}
        // GET: Data/{*name}/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Read(string name, Guid id)
        {
            return Select(name, id);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(string name, Guid id)
        {
            const string MissmatchError = "Only model type entities can be accessed this way ({0} found on this path). If you are looking for the metadata, use Data/[*name]/$metadata path instead.";
            const string UnexpectedError = "Unexpected error";

            string message = null;
            RavenJObject data = null;

            var descriptor = DataDictionary.Current.Describe(name);

            if (descriptor == null)
            {
                message = "Name not Found";
            }
            else if (descriptor.Type == NodeKinds.Error)
            {
                message = (descriptor as ErrorDescriptor).Message;
            }
            else if (descriptor.Type != NodeKinds.Type)
            {
                message = string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type));
            }
            else
            {
                var type = descriptor as TypeDescriptor;

                if (TypeCategories.Model != type.Category)
                {
                    message = string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type));
                }
                else
                {
                    var model = type as ModelDescriptor;

                    var repository = model.Repository;

                    if (repository != null)
                    {
                        if (model.Definition.Singleton)
                        {
                        }
                        else if (Guid.Empty.Equals(id))
                        {
                            data = repository.Read(0, 100);
                        }
                        else
                        {
                            data = repository.Read(id);
                        }

                        if (data != null)
                        {
                            return Success(data);
                        }

                        message = "Entity not found";
                    }
                    else
                    {
                        message = "Could not resolve repository";
                    }
                }
            }

            if (data == null)
            {
                data = new RavenJObject();
            }

            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);
            data["id"] = new RavenJValue(id);

            return Failure(data, message);
        }

        //
        // POST: Data/{*name}
        // POST: Data/{*name}/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string name)
        {
            return Insert(name);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Insert(string name)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);

            return Success(data);
        }

        // 
        // PUT: Data/{*name}/{id}?patch={patch}
        // PUT: Data/{*name}/{id}/{Update|Edit}?patch={patch}
        // PATCH: Data/{*name}/{id}
        // PATCH: Data/{*name}/{id}/{Update|Edit}
        // POST: Data/{*name}/{id}/{Update|Edit}?patch={patch}

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Edit(string name, Guid id, bool patch)
        {
            return Update(name, id, patch);
        }

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(string name, Guid id, bool patch)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);
            data["id"] = new RavenJValue(id);

            return Failure(data, "Not found");
        }

        // 
        // DELETE: Data/{*name}/{id}
        // DELETE: Data/{*name}/{id}/{Delete|Destroy}
        // POST: Data/{*name}/{id}/{Delete|Destroy}
        // GET: Data/{*name}/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(string name, Guid id)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);
            data["id"] = new RavenJValue(id);

            return Failure(data, "Not found");
        }

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Destroy(string name, Guid id)
        {
            return Delete(name, id);
        }

        // POST: Data/{*name}/Validate
        // POST: Data/{*name}/{id}/Validate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Validate(string name, Guid id)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);
            data["id"] = new RavenJValue(id);

            return Failure(data, "Not found");
        }

        // GET: Data/{*name}/{Invoke|Call}/{fn}
        // GET: Data/{*name}/{id}/{Invoke|Call}/{fn}
        // POST: Data/{*name}/{Invoke|Call}/{fn}
        // POST: Data/{*name}/{id}/{Invoke|Call}/{fn}

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Call(string name, Guid id, string fn)
        {
            return Invoke(name, id, fn);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Invoke(string name, Guid id, string fn)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["name"] = new RavenJValue(name);
            data["id"] = new RavenJValue(id);

            return Failure(data, "Not found");
        }
    }
}
