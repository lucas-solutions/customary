﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Page : Resource
    {
        public Page(RavenJObject data, Master parent, string path)
            : base(data, parent, path)
        {
        }

        public List<Component> Content
        {
            get;
            set;
        }

        #region - mvc -

        public override string MvcControllerName
        {
            get { return "Page"; }
        }

        #endregion - mvc -
    }
}