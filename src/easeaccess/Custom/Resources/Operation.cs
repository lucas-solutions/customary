using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Operation : Component
    {
        public Operation(RavenJObject data, Master parent, string path)
            : base(data, parent, path)
        {
        }
    }
}