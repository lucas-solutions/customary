using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Custom.Binders
{
    using Custom.Models;

    public class GridBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var reflection = (RequestReflection)controllerContext.HttpContext;
            return reflection.Grid;
        }
    }
}
