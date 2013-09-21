using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Custom.Results
{
    public abstract class CustomResult : ActionResult
    {
        private ControllerContext _controllerContext;
        private IView _view;

        protected Cache Cache
        {
            get { return HostingEnvironment.Cache; }
        }

        public ControllerContext ControllerContext
        {
            get { return _controllerContext; }
            set { _controllerContext = value; }
        }

        public IView View
        {
            get { return _view ?? (_view = Cache.Get(ViewKey) as IView); }
            set { Cache.Add(ViewKey, _view = value, null, DateTime.Now.Add(TimeSpan.FromMinutes(10)), Cache.NoSlidingExpiration, CacheItemPriority.Default, null); }
        }

        protected abstract string ViewKey
        {
            get;
        }
    }
}