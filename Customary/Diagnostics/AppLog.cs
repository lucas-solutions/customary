using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Diagnostics
{
    public class AppLog : WebLog<AppLog>
    {
        public AppLog(ILogger logger)
            : this(logger, null)
        {
        }

        public AppLog(ILogger logger, IDictionary<string, object> data)
            : base(logger, data)
        {
        }
    }
}