using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{

    using Raven.Json.Linq;

    public class PropertyDescriptor : MemberDescriptor
    {
        public PropertyDescriptor(RavenJObject value, TypeDescriptor owner)
            :  base(value, owner)
        {
        }

        public override MemberType Type
        {
            get { return MemberType.Member; }
        }

        public bool Array
        {
            get { return _value.Value<bool>("array"); }
            set { _value["array"] = value; }
        }

        public bool Required
        {
            get { return _value.Value<bool>("required"); }
            set { _value["required"] = value; }
        }
    }
}
