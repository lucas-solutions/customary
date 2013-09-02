using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Json.Linq;
    using System.Web.Routing;

    public abstract class Component : Metadata
    {
        protected const string Separator = @"/";

        private readonly string _path;

        protected Component(RavenJObject data, string path)
            : base(data)
        {
            _path = path;
        }

        public string Area
        {
            get;
            set;
        }

        public string Name
        {
            get { return _data.Value<string>("Name"); }
            set { _data["Name"] = value; }
        }

        public string Path
        {
            get { return _path; }
        }

        public virtual Component Lookup(Lookup session)
        {
            return null;
        }
    }
}