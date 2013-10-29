using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public class EnumDefinition : TypeDefinition
    {
        private List<MemberDefinition> _members;

        public List<MemberDefinition> Members
        {
            get { return _members ?? (_members = new List<MemberDefinition>()); }
            set { _members = value; }
        }
    }
}