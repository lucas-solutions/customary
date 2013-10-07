using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public sealed class ComplexDescriptor : ObjectDescriptor
    {
        public bool Generic
        {
            get;
            set;
        }

        /// <summary>
        /// Generic arguments. If generic is set to true.
        /// </summary>
        public List<string> Arguments
        {
            get;
            set;
        }
    }
}
