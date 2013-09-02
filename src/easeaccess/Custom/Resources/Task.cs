using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Task : Component
    {
        public Task(RavenJObject data, Master parent, string path)
            : base(data, parent, path)
        {
        }

        #region - mvc -

        public override string MvcControllerName
        {
            get { return "Screen"; }
        }

        #endregion - mvc -
    }
}