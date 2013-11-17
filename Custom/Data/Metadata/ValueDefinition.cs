using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public sealed class ValueDefinition : TypeDefinition
    {
        public ValueUI UI
        {
            get;
            set;
        }

        public List<ValidationDefinition> Validations
        {
            get;
            set;
        }
    }
}