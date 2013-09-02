using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Member : Metadata<MemberObject>
    {
        private readonly Enum _enum;

        public Member(RavenJObject data, Enum enm)
            : base(data)
        {
            _enum = enm;
        }

        public Enum Enum
        {
            get { return _enum; }
        }

        #region - mvc -

        public override string MvcRouteName
        {
            get { return Enum.MvcRouteName; }
        }

        public override string MvcAreaName
        {
            get { return Enum.MvcAreaName; }
        }

        public override string MvcControllerName
        {
            get { return "Member"; }
        }

        #endregion - mvc -
    }
}