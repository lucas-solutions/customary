using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public class MemberDescriptor : Component
    {
        private readonly TypeDescriptor _owner;

        public MemberDescriptor(RavenJObject value, TypeDescriptor owner)
            :  base("name", value)
        {
            _owner = owner;
        }

        public string Name
        {
            get { return _value.Value<string>("name"); }
            set { _value["name"] = value; }
        }

        public virtual MemberType Type
        {
            get { return MemberType.Member; }
        }

        public TypeDescriptor Owner
        {
            get { return _owner; }
        }
    }
}