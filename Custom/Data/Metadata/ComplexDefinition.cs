using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public sealed class ComplexDefinition : StructuralDefinition
    {
        public bool Generic
        {
            get;
            set;
        }

        /// <summary>
        /// Generic arguments. If generic is set to true.
        /// { name, type }
        /// </summary>
        public Dictionary<string, string> Arguments
        {
            get;
            set;
        }
    }
}
