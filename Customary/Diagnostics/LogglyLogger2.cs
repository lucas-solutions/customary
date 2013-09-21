using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Diagnostics
{
    public class LogglyLogger2 : LogglyLogger
    {
        public LogglyLogger2(string inputKey, string alternativeUrl = null)
            : base(inputKey, alternativeUrl ?? "logs-01.loggly.com/")
        {
        }
    }
}