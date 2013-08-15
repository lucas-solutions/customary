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

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            var time = Stopwatch.GetTimestamp() - _startTime;
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            _startTime = Stopwatch.GetTimestamp();
        }

        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
        }

        /// <summary>
        /// This method occurs when the result has been executed (this is just 
        /// before the response is returned). 
        /// This method records the latency from request begin to response return.
        /// </summary>
        /// <param name="filterContext"></param>
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Stop counter for latency
            var time = Stopwatch.GetTimestamp() - _startTime;

            var countManager = GetPerformanceCounterManager(filterContext.HttpContext);

            if (countManager != null)
            {
                countManager.RecordLatency(Instance, time);
            }
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