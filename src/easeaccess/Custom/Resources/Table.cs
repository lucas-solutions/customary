using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Table : Component
    {
        public Table(RavenJObject data, Master parent, string path)
            : base(data, parent, path)
        {  
        }

        #region - mvc -

        public override string MvcControllerName
        {
            get { return "Table"; }
        }

        #endregion - mvc -
    }
}