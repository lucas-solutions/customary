using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Filters
{
    using Custom.Diagnostics;

    /// <summary>
    /// Easily Add Performance Counters to Your MVC Application:
    /// http://msdn.microsoft.com/en-us/magazine/hh288078.aspx
    /// </summary>
    public class DiagnosticsAttribute : FilterAttribute, IActionFilter, IExceptionFilter, IResultFilter
    {
        private long _startTime = 0;
        private IDictionary<string, object> _data = new Dictionary<string, object>();
        private Exception _exception;

        public string Category
        {
            get;
            set;
        }

        public string Instance
        {
            get;
            set;
        }

        private ILogger Logger
        {
            get { return Global.Logger; }
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            _data["Controller"] = filterContext.RouteData.Values["controller"];
            _data["Action"] = filterContext.RouteData.Values["action"];
            
            var time = Stopwatch.GetTimestamp() - _startTime;

            Logger.Log(string.Format("Action Controller: {1}, Action: {2} took {0}", time, filterContext.RouteData.Values["controller"], filterContext.RouteData.Values["action"]));
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            _data["Controller"] = filterContext.RouteData.Values["controller"];
            _data["Action"] = filterContext.RouteData.Values["action"];
            _data["ActionStartTime"] = _startTime = Stopwatch.GetTimestamp();
        }

        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            _data["Controller"] = filterContext.RouteData.Values["controller"];
            _data["Action"] = filterContext.RouteData.Values["action"];

            _exception = filterContext.Exception;
        }

        /// <summary>
        /// This method occurs when the result has been executed (this is just 
        /// before the response is returned). 
        /// This method records the latency from request begin to response return.
        /// </summary>
        /// <param name="filterContext"></param>
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            _data["Controller"] = filterContext.RouteData.Values["controller"];
            _data["Action"] = filterContext.RouteData.Values["action"];

            // Stop counter for latency
            var time = Stopwatch.GetTimestamp() - _startTime;

            Logger.Log(string.Format("Result Controller: {1}, Action: {2} took {0}", time, filterContext.RouteData.Values["controller"], filterContext.RouteData.Values["action"]));

            /*var countManager = GetPerformanceCounterManager(filterContext.HttpContext);

            if (countManager != null)
            {
                countManager.RecordLatency(Instance, time);
            }*/

            _data["Controller"] = filterContext.RouteData.Values["controller"];
            _data["Action"] = filterContext.RouteData.Values["action"];
        }

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            _startTime = Stopwatch.GetTimestamp();
        }

        private DiagnosticsManager GetPerformanceCounterManager(HttpContextBase context)
        {
            DiagnosticsManager manager = context.Application[DiagnosticsManager.PerformanceCounterManagerApplicationKey] as DiagnosticsManager;

            return manager;
        } 
    }
}