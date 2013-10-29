using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public sealed class ComplexAttribute : StructuralAttribute
    {
        public ComplexAttribute(string id)
            : base(id)
        {
        }
    }
}
