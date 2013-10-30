using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class UnitDefinition : TypeDefinition
    {
        public Dictionary<string, double> Measurements { get; set; }
    }
}
