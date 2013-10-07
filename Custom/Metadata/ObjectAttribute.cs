using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public abstract class ObjectAttribute : TypeAttribute
    {
        protected ObjectAttribute(string id)
            : base(id)
        {
        }
    }
}
