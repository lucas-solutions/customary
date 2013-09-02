using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Client.Indexes;
    using Raven.Json.Linq;

    public class Resource : Document
    {
        protected Resource(RavenJObject value)
            : base(value)
        {
        }

        protected Resource(string key, RavenJObject value)
            : base(key, value)
        {
        }

        public string Name
        {
            get { return _value.Value<string>("Name"); }
            set { _value["Name"] = value; }
        }

        public string Area
        {
            get { return _value.Value<string>("Area"); }
            set { _value["Area"] = value; }
        }
    }
}
