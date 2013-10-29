using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    using Custom.Diagnostics;

    public static class LoggerExtensions
    {
        public static TLog LogRequest<TLog>(this ILogger logger)
            where TLog : RequestLog<TLog>
        {
            return logger.Log<TLog>();
        }

        public static TLog LogScript<TLog, TLogger>(this ILogger logger)
            where TLog : ScriptLog<TLog>
        {
            return logger.Log<TLog>();
        }
    }
}