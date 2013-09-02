using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Property : Metadata<PropertyObject>
    {
        private readonly Model _model;

        public Property(RavenJObject data, Model model)
            : base(data)
        {
            _model = model;
        }

        public Model Model
        {
            get { return _model; }
        }

        #region - mvc -

        public override string MvcControllerName
        {
            get { return "Property"; }
        }

        #endregion - mvc -
    }
}