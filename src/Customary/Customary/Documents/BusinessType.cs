using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Custom.Reflection;

    public abstract class BusinessType : MemberDescriptor
    {
        List<MemberDescriptor> _members;

        public string Namespace { get; set; }

        public List<MemberDescriptor> Members
        {
            get { return _members ?? (_members = new List<MemberDescriptor>()); }
            set { _members = value; }
        }
    }
}