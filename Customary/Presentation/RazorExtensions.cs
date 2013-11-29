using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    using Custom.Results;
    using Custom.Presentation;

    public static class RazorExtensions
    {
        public static string Absolute(this UrlHelper url, string path = null)
        {
            var request = url.RequestContext.HttpContext.Request;
            var root = request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + request.ApplicationPath;
            path = path != null ? path.TrimStart('~', '/') : string.Empty;
            return new Uri(new Uri(root, UriKind.Absolute), path).ToString().TrimEnd('/');
        }

        /// <summary>
        /// Render script view.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="viewName">Script view path and name</param>
        public static void RenderScript(this HtmlHelper helper, string viewName)
        {
            var view = helper.ViewContext.View;
            var controllerContext = helper.ViewContext.Controller.ControllerContext;
            var viewData = helper.ViewContext.ViewData;
            var tempData = helper.ViewContext.TempData;

            var scriptViewResult = new ScriptViewResult
                {
                    ControllerContext = controllerContext,
                    Model = helper.ViewData.Model,
                    TempData = tempData,
                    ViewData = viewData,
                    ViewName = viewName,
                };

            scriptViewResult.Strip = true;
            scriptViewResult.TrimLeft = true;

            scriptViewResult.Write(helper.ViewContext.Writer);
        }

        /// <summary>
        /// Partial script view.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="viewName">Script view path and name</param>
        public static IHtmlString PartialScript(this HtmlHelper helper, string viewName)
        {
            var view = helper.ViewContext.View;
            var controllerContext = helper.ViewContext.Controller.ControllerContext;
            var viewData = helper.ViewContext.ViewData;
            var tempData = helper.ViewContext.TempData;

            var scriptViewResult = new ScriptViewResult
            {
                ControllerContext = controllerContext,
                Model = helper.ViewData.Model,
                TempData = tempData,
                ViewData = viewData,
                ViewName = viewName,
            };

            scriptViewResult.Strip = true;
            scriptViewResult.TrimLeft = true;

            return scriptViewResult;
        }

        /// <summary>
        /// Render same view with new model.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="model">model</param>
        public static void Render(this HtmlHelper helper, object model)
        {
            var view = helper.ViewContext.View;
            var controllerContext = helper.ViewContext.Controller.ControllerContext;
            var viewData = helper.ViewContext.ViewData;
            var tempData = helper.ViewContext.TempData;
            

            if (System.Web.Hosting.HostingEnvironment.IsDevelopmentEnvironment)
            {
                viewData.Model = model;
                
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    var viewContext = new ViewContext(controllerContext, view, viewData, tempData, sw);
                    view.Render(viewContext, sw);
                }

                var lines = new List<string>();
                using (var sr = new StringReader(sb.ToString()))
                {
                    for (var line = sr.ReadLine(); line != null; line = sr.ReadLine())
                        lines.Add(line);
                }

                lines.TrimLeft();

                var writer = helper.ViewContext.Writer;

                foreach (var line in lines)
                    writer.WriteLine(line);
            }
            else
            {
                var writer = helper.ViewContext.Writer;
                var viewContext = new ViewContext(controllerContext, view, viewData, tempData, writer);
                viewData.Model = model;
                view.Render(viewContext, writer);
            }
        }

        public static HelperResult Result(this Scriptable scriptale)
        {
            return new HelperResult(writer =>
                {
                    var lines = new List<string>();
                    scriptale.Render(lines);
                    writer.WriteAllLines(lines);
                });
        }

        public static HelperResult List<T>(this IEnumerable<T> items, Func<T, HelperResult> template)
        {
            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }

        public static HelperResult NotNull(this object[] list, Func<HelperResult> template)
        {
            if (list.Any(o => o != null))
                return null;

            return new HelperResult(writer =>
            {
                template().WriteTo(writer);
            });
        }

        public static HelperResult NotLast<T>(this List<T> items, int index, Func<T, HelperResult> template)
        {
            if (items == null || index == items.Count - 1)
                return null;

            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }

        public static HelperResult Last<T>(this List<T> items, int index, Func<T, HelperResult> template)
        {
            if (items != null && index < items.Count - 1)
                return null;

            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }
    }
}