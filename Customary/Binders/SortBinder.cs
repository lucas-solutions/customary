using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Binders
{
    using Newtonsoft.Json;
    
    using Sort = Custom.Models.Sort;

    public class SortBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = controllerContext.HttpContext.Request.QueryString["sort"];

            if (string.IsNullOrEmpty(value))
                return null;

            if (bindingContext.ModelType.Is(typeof(Sort)))
                return JsonConvert.DeserializeObject<Sort>(value);
            else if (typeof(IEnumerable).IsAssignableFrom(bindingContext.ModelType))
            {
                var model = JsonConvert.DeserializeObject<List<Sort>>(value);

                if (typeof(List<Sort>).IsAssignableFrom(bindingContext.ModelType))
                    return model;

                if (typeof(Collection<Sort>).IsAssignableFrom(bindingContext.ModelType))
                    return new Collection<Sort>(model);

                if (typeof(Sort[]).IsAssignableFrom(bindingContext.ModelType))
                    return model.ToArray();

                return model;
            }
            return null;
        }
    }
}