using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public abstract class Resource : Component
    {
        protected Resource(RavenJObject data, Master parent, string path)
            : base(data, parent, path)
        {
        }

        #region - mvc -

        public override string MvcRouteName
        {
            get { return Parent.MvcRouteName; }
        }

        public override string MvcAreaName
        {
            get { return Parent.MvcAreaName; }
        }

        #endregion - mvc -

        public string Name
        {
            get { return Path.Replace('/', '.') + '.'  + Name; }
        }
    }
}