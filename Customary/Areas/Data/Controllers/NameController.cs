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
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;
    using System.Web.Routing;

    public class NameController : CustomController
    {
        //
        // GET: data.{domain}/{*name}/{id}

        public ActionResult Default(string name, Guid id)
        {
            ViewBag.Title = "Data Dictionary";
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
            var requires = extra != null ? extra.Requires : new string[] { };

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

            RavenJObjectResult result = null;

            var descriptor = DataDictionary.Current.Describe(name);

            if (descriptor == null)
            {
                result = Failure("Name not Found");
            }
            else if (descriptor.Type == NodeKinds.Error)
            {
                result = Failure((descriptor as ErrorDescriptor).Message);
            }
            else if (descriptor.Type != NodeKinds.Type)
            {
                result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
            }
            else
            {
                var type = descriptor as TypeDescriptor;

                if (TypeCategories.Model != type.Category)
                {
                    result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
                }
                else
                {
                    var model = type as ModelDescriptor;

                    var repository = model.Repository;

                    if (repository != null)
                    {
                        if (model.Definition.Singleton)
                        {
                            result = new RavenJObjectResult { Content = repository.Read(Guid.Empty) };
                        }
                        else if (Guid.Empty.Equals(id))
                        {
                            result = new RavenJObjectResult { Content = repository.Read(0, 100) };
                        }
                        else
                        {
                            result = new RavenJObjectResult { Content = repository.Read(id) };
                        }
                    }
                    else
                    {
                        result = Failure("Could not resolve repository");
                    }
                }
            }

            result.Content["route"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
            {
                result.Content[item.Key] = new RavenJValue(item.Value);
            }

            result.Content["name"] = new RavenJValue(name);
            if (!id.Equals(Guid.Empty))
            {
                result.Content["id"] = new RavenJValue(id);
            }

            return result;
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
            const string MissmatchError = "Only model type entities can be accessed this way ({0} found on this path). If you are looking for the metadata, use Data/[*name]/$metadata path instead.";
            const string UnexpectedError = "Unexpected error";

            RavenJObjectResult result = null;

            var descriptor = DataDictionary.Current.Describe(name);

            if (descriptor == null)
            {
                result = Failure("Name not Found");
            }
            else if (descriptor.Type == NodeKinds.Error)
            {
                result = Failure((descriptor as ErrorDescriptor).Message);
            }
            else if (descriptor.Type != NodeKinds.Type)
            {
                result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
            }
            else
            {
                var type = descriptor as TypeDescriptor;

                if (TypeCategories.Model != type.Category)
                {
                    result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
                }
                else
                {
                    var model = type as ModelDescriptor;

                    var repository = model.Repository;

                    if (repository != null)
                    {
                        var body = this.InputRavenJObject;
                        var data = body["data"];

                        if (data != null)
                        {
                            switch (data.Type)
                            {
                                case JTokenType.Array:
                                    result = new RavenJObjectResult { Content = repository.Update(data as RavenJArray, patch) };
                                    break;

                                case JTokenType.Object:
                                    if (Guid.Empty.Equals(id))
                                    {
                                        result = new RavenJObjectResult { Content = repository.Update(data as RavenJObject, patch) };
                                    }
                                    else
                                    {
                                        result = new RavenJObjectResult { Content = repository.Update(id, data as RavenJObject, patch) };
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            result = Failure("Invalid request. 'data' property expected");
                        }

                    }
                    else
                    {
                        result = Failure("Could not resolve repository");
                    }
                }
            }

            result.Content["route"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
            {
                result.Content[item.Key] = new RavenJValue(item.Value);
            }

            result.Content["name"] = new RavenJValue(name);
            if (!id.Equals(Guid.Empty))
            {
                result.Content["id"] = new RavenJValue(id);
            }

            return result;
        }

        // 
        // DELETE: Data/{*name}/{id}
        // DELETE: Data/{*name}/{id}/{Delete|Destroy}
        // POST: Data/{*name}/{id}/{Delete|Destroy}
        // GET: Data/{*name}/{id}/{Delete|Destroy}

        // 
        // DELETE: Data/{*name}/{id}/{property}/{index}
        // DELETE: Data/{*name}/{id}/{property}/{index}/{Delete|Destroy}
        // POST: Data/{*name}/{id}/{property}/{index}/{Delete|Destroy}
        // GET: Data/{*name}/{id}/{property}/{index}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(string name, Guid id, string property, string index)
        {
            const string MissmatchError = "Only model type entities can be accessed this way ({0} found on this path). If you are looking for the metadata, use Data/[*name]/$metadata path instead.";
            const string UnexpectedError = "Unexpected error";

            RavenJObjectResult result = null;

            var descriptor = DataDictionary.Current.Describe(name);

            if (descriptor == null)
            {
                result = Failure("Name not Found");
            }
            else if (descriptor.Type == NodeKinds.Error)
            {
                result = Failure((descriptor as ErrorDescriptor).Message);
            }
            else if (descriptor.Type != NodeKinds.Type)
            {
                result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
            }
            else
            {
                var type = descriptor as TypeDescriptor;

                if (TypeCategories.Model != type.Category)
                {
                    result = Failure(string.Format(MissmatchError, System.Enum.GetName(typeof(NodeKinds), descriptor.Type)));
                }
                else
                {
                    var model = type as ModelDescriptor;

                    var repository = model.Repository;

                    if (repository != null)
                    {
                        var body = this.InputRavenJObject;
                        var data = body["data"];

                        if (data != null)
                        {
                            switch (data.Type)
                            {
                                case JTokenType.Array:
                                    result = new RavenJObjectResult { Content = repository.Delete(data as RavenJArray) };
                                    break;

                                case JTokenType.Object:
                                    result = new RavenJObjectResult { Content = repository.Delete(data as RavenJObject) };
                                    break;
                            }
                        }
                        else if (Guid.Empty.Equals(id))
                        {
                            result = Failure("Invalid request. id param expected");
                        }
                        else
                        {
                            result = new RavenJObjectResult { Content = repository.Delete(id) };
                        }
                    }
                    else
                    {
                        result = Failure("Could not resolve repository");
                    }
                }
            }

            result.Content["route"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
            {
                result.Content[item.Key] = new RavenJValue(item.Value);
            }

            result.Content["name"] = new RavenJValue(name);
            if (!id.Equals(Guid.Empty))
            {
                result.Content["id"] = new RavenJValue(id);
            }

            return result;
        }

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Destroy(string name, Guid id, string property, string index)
        {
            return Delete(name, id, property, index);
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
