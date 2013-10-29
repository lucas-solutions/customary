using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class UnitAttribute : MemberAttribute
    {
        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public string Symbol { get; set; }

        public string Sign { get; set; }

        public bool IsSuffix { get; set; }
    }
}
