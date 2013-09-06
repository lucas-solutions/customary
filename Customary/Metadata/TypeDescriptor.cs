using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public abstract class TypeDescriptor : MemberDescriptor
    {
        private Guid? _id;
        private string _name;
        private List<MemberDescriptor> _members;

        public Guid ID
        {
            get { return _id.HasValue ? _id.Value : (_id = Guid.NewGuid()).Value; }
            set { _id = value; }
        }

        public override string Name
        {
            get { return _name ?? (_name = ID.ToString("N")); }
            set { _name = value; }
        }

        public string Namespace
        {
            get;
            set;
        }

        public List<MemberDescriptor> Members
        {
            get { return _members ?? (_members = new List<MemberDescriptor>()); }
            set { _members = value; }
        }
    }
}