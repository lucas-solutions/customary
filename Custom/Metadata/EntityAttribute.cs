using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public class EntityAttribute : ObjectAttribute
    {
        public EntityAttribute(string id)
            : base(id)
        {
        }
    }
}
