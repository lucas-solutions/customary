using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public class TypeDescriptor : Document
    {
        private Collection<MemberDescriptor> _members;

        public TypeDescriptor(RavenJObject value)
            : base(value)
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
        
        public Collection<MemberDescriptor> Members
        {
            get
            {
                if (_members == null)
                {
                    var array = _value.Value<RavenJArray>("Properties");

                    if (array == null)
                    {
                        array = new RavenJArray();
                        _value["Properties"] = array;
                    }

                    _members = new Collection<MemberDescriptor>("Name", array, this);
                }

                return _members;
            }
        }
    }
}
