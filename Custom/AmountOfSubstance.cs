using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    [Data.Metadata.Enum("6e9b92a5-795f-4833-a510-fa8be76429a0")]
    public sealed class AmountOfSubstance : Measurement<AmountOfSubstance>
    {
        static AmountOfSubstance _default = null;
        static readonly AmountOfSubstance[] _members = GetMembers();

        public static AmountOfSubstance Default
        {
            get { return _default; }
            set { _default = value; }
        }

        public AmountOfSubstance()
            : base(null)
        {
        }

        private AmountOfSubstance(string name, decimal value)
            : base(name)
        {
        }

        protected override AmountOfSubstance[] Members
        {
            get { return _members; }
        }
    }
}
