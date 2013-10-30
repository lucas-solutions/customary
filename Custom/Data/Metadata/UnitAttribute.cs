using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class UnitAttribute: TypeAttribute
    {
        public UnitAttribute(string id)
            : base(id)
        {
        }
    }
}
