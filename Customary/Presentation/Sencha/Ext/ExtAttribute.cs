using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public class ExtAttribute : Attribute
    {
        public ExtAttribute()
        {
        }

        public ExtAttribute(string name)
        {
        }

        public ExtAttribute(ExtMemberTypes type)
        {
        }
    }
}