using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public abstract class StructuralAttribute : TypeAttribute
    {
        protected StructuralAttribute(string id)
            : base(id)
        {
        }
    }
}
