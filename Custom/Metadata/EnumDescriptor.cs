using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public class EnumDescriptor : TypeDescriptor
    {
        private List<MemberDescriptor> _members;

        public List<MemberDescriptor> Members
        {
            get { return _members ?? (_members = new List<MemberDescriptor>()); }
            set { _members = value; }
        }
    }
}