using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public class MemberDefinition : BaseDefinition
    {
        public MemberUI UI
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }
    }
}