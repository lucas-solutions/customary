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
        private long _actionExecuting;
        private long _actionExecuted;
        private long _resultExecuting;
        private long _resultExecuted;
        private Exception _exception;
        private ControllerLog _log;

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

        private void Log()
        {
            if (_log != null && !_log.Completed)
                _log.Send();
        }

        private ControllerLog Log(ControllerBase controller)
        {
            var customController = controller as Custom.Web.Mvc.CustomController;
            if (customController != null)
            {
                var log = customController.Log;

                if (log != null)
                    _log = log;
                if (_log != null)
                    customController.Log = _log;
                else
                {
                    customController.Log = _log = Global.Logger.Log<ControllerLog>();
                }
            }
            return _log;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            _actionExecuted = DateTime.UtcNow.Ticks;

            var latency = _actionExecuted - _actionExecuting;

            Log(filterContext.Controller)
                .ActionLatency(TimeSpan.FromTicks(latency))
                .Duration(TimeSpan.FromTicks(latency));
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.Controller)
                .Timestamp(DateTime.Now)
                .Controller(filterContext.Controller);

            _actionExecuting = DateTime.UtcNow.Ticks;
        }

        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            _exception = filterContext.Exception;

            var duration = DateTime.UtcNow.Ticks - _actionExecuting;

            Log(filterContext.Controller)
                .Duration(TimeSpan.FromTicks(duration))
                .Error(filterContext.Exception);
        }

        /// <summary>
        /// This method occurs when the result has been executed (this is just 
        /// before the response is returned). 
        /// This method records the latency from request begin to response return.
        /// </summary>
        /// <param name="filterContext"></param>
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
        {
            _resultExecuted = DateTime.UtcNow.Ticks;
            
            var latency = _resultExecuted - _resultExecuting;
            var duration = _resultExecuted - _actionExecuting;

            Log(filterContext.Controller)
                .ResultLatency(TimeSpan.FromTicks(latency))
                .Duration(TimeSpan.FromTicks(duration));

            /*var countManager = GetPerformanceCounterManager(filterContext.HttpContext);

            if (countManager != null)
            {
                countManager.RecordLatency(Instance, latency);
            }*/        }

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
        {
            _resultExecuting = DateTime.UtcNow.Ticks;
            
            var duration = _resultExecuting - _actionExecuting;

            Log(filterContext.Controller)
                .Duration(TimeSpan.FromTicks(duration));
        }

        /*private DiagnosticsManager GetPerformanceCounterManager(HttpContextBase context)
        {
            DiagnosticsManager manager = context.Application[DiagnosticsManager.PerformanceCounterManagerApplicationKey] as DiagnosticsManager;

            return manager;
        }*/
    }
}