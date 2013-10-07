using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public class ElectricCurrent : Measurement<ElectricCurrent>
    {
        static ElectricCurrent _default = null;
        static readonly ElectricCurrent[] _members = GetMembers();

        public static ElectricCurrent Default
        {
            get { return _default; }
            set { _default = value; }
        }

        public ElectricCurrent()
            : base(null)
        {
        }

        private ElectricCurrent(string name, decimal value)
            : base(name)
        {
        }

        protected override ElectricCurrent[] Members
        {
            get { return _members; }
        }
    }
}
