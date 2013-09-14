using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Custom.Diagnostics
{
    public class WebLog<TLog> : Log<TLog>
         where TLog : WebLog<TLog>
    {
        public WebLog(ILogger logger)
            : this(logger, null)
        {
        }

        public WebLog(ILogger logger, IDictionary<string, object> data)
            : base(logger, data)
        {
            this
                .Application(HostingEnvironment.SiteName)
                .Application(HostingEnvironment.ApplicationID)
                .Development(HostingEnvironment.IsDevelopmentEnvironment);
        }

        public TLog Development(bool value)
        {
            Context["Development"] = value;
            return (TLog)this;
        }
    }
}