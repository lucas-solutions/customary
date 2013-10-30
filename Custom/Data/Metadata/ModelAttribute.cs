using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public sealed class ModelAttribute : TypeAttribute
    {
        public ModelAttribute(string id)
            : base(id)
        {
        }
    }
}
