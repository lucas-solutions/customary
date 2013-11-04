using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Custom.Models
{
    public class Page : IDisposable
    {
        public static implicit operator ActionResult(Page page)
        {
            page._actionResult.ViewBag.Title = page.Title;
            return page._actionResult;
        }

        private readonly ControllerContext _controllerContext;
        private readonly ViewEngineResult _viewEngineResult;
        private readonly object _model;
        private readonly PartialViewResult _actionResult;

        public Page(Controller controller, object model)
        {
            _controllerContext = controller.ControllerContext;
            _model = model;

            var areaName = controller.RouteData.Values["area"];
            var controllerName = controller.RouteData.Values["controller"];
            var actionName = controller.RouteData.Values["action"];

            var viewName = areaName != null
                ? string.Format("~/Areas/{0}/Views/{1}/{2}.cshtml", areaName, controllerName, actionName)
                : string.Format("~/Views/{0}/{1}.cshtml", controllerName, actionName);

            _viewEngineResult = controller.ViewEngineCollection.FindPartialView(_controllerContext, viewName/*(string)controller.RouteData.Values["action"]*/);

            controller.ViewData.Model = this;

            _actionResult = new PartialViewResult
            {
                ViewName = "_Page",
                ViewData = controller.ViewData,
                TempData = controller.TempData,
                ViewEngineCollection = controller.ViewEngineCollection
            };

            //Cache.Add(viewName, page, null, DateTime.Now.Add(TimeSpan.FromMinutes(1)), Cache.NoSlidingExpiration, CacheItemPriority.Default, ViewResultRemoved);
        }

        public string Title
        {
            get;
            set;
        }

        void IDisposable.Dispose()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_viewEngineResult != null)
                _viewEngineResult.ViewEngine.ReleaseView(_controllerContext, _viewEngineResult.View);
        }

        public void Render(TextWriter writer)
        {
            var viewContext = new ViewContext(_controllerContext, _viewEngineResult.View, _actionResult.ViewData, _actionResult.TempData, writer);
            viewContext.ViewData.Model = _model;
            viewContext.ViewBag.Title = Title;
            viewContext.View.Render(viewContext, writer);
        }

        private static void ViewResultRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            var page = value as Page;
            page.Dispose();
        }
    }

    public static class PageExtensions
    {
        public static Page Page(this Controller controller, object model)
        {
            return new Page(controller, model);
        }
    }
}