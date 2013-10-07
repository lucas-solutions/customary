using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public sealed class ComplexAttribute : ObjectAttribute
    {
        public ComplexAttribute(string id)
            : base(id)
        {
        }
    }
}
