using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public sealed class LuminousIntensity : Measurement<LuminousIntensity>
    {
        static readonly LuminousIntensity[] _members;

        static LuminousIntensity()
        {
            _members = GetMembers();
        }

        public LuminousIntensity()
            : base(null)
        {
        }

        private LuminousIntensity(string name, decimal value)
            : base(name)
        {
        }

        protected override LuminousIntensity[] Members
        {
            get { return _members; }
        }
    }
}
