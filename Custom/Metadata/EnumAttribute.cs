using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public class EnumAttribute : TypeAttribute
    {
        public EnumAttribute(string id)
            : base(id)
        {
        }
    }
}
