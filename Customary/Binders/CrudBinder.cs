using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Custom.Binders
{
    using Custom.Web;

    public class CrudBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            Debug.Assert(bindingContext.ModelType == typeof(CrudActions));

            var stringValue = actionContext.ControllerContext.RouteData.Values[bindingContext.ModelName] as string;

            CrudActions verb;
            bindingContext.Model = (!string.IsNullOrEmpty(stringValue) && System.Enum.TryParse<CrudActions>(stringValue, out verb))
                ? verb
                : CrudActions.Default;

            return true;
        }
    }
}