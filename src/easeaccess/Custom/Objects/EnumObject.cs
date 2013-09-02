using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class EnumObject : ResourceObject
    {
        public List<MemberObject> Members
        {
            get;
            set;
        }
    }
}