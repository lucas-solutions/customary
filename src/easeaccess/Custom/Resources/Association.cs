using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    /// <summary>
    /// Model-Model Association
    /// </summary>
    public class Association : Metadata<AssociationObject>
    {
        public Association(RavenJObject data, Master parent, string path)
            : base(data)
        {
        }
    }
}