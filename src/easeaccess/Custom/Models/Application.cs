using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Application : Area
    {
        public Application(RavenJObject data, Master master)
            : base(data, null)
        {
        }

        public override string Path
        {
            get { return "Applications" + Name; }
        }
    }
}