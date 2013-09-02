using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Processes
{
    using Custom.Objects;
    using Custom.Resources;

    public class AppProcesses : ResourceProcesses<App, AppObject, Service>
    {
        public AppProcesses(App app)
            : base(app)
        {
        }
    }
}