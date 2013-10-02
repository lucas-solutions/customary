using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Extensions;
    using Custom.Models;
    using Custom.Processes;
    using Custom.Transforms;
    using Custom.Utils;

    public abstract class ReflectionController : Controller
    {
        
        private readonly Reflection _reflection;

        private JsonRequestBehavior _jsonReqBehavior = JsonRequestBehavior.AllowGet;

        public ReflectionController()
        {
            if (HttpContext != null)
            {
                _reflection = (RequestReflection)HttpContext;
            }
            else
            {
                _reflection = (RequestReflection)System.Web.HttpContext.Current;
            }
        }

        protected Reflection Reflection
        {
            get { return _reflection; }
        }
    }
}
