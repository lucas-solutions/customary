using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    using Custom.Diagnostics;

    public class ScriptLog<TLog> : RequestLog<TLog>
        where TLog : ScriptLog<TLog>
    {
        public ScriptLog(ILogger logger)
            : this(logger, null)
        {
        }

        public ScriptLog(ILogger logger, IDictionary<string, object> data)
            : base(logger, data)
        {
        }

        public TLog Script(string value)
        {
            Context["Script"] = value;
            return (TLog)this;
        }
    }
}