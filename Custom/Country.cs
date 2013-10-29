using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    [Data.Metadata.Enum("c806e046-4603-432e-95f4-16f654fa2e1a")]
    public sealed class Country : Enum<Country, int>
    {
        static readonly Country[] _members = GetMembers();

        public static readonly Country Cuba = new Country("Cuba", "CU", ".cu", 53);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">English short country name officially used by the ISO 3166 Maintenance Agency (ISO 3166/MA)</param>
        /// <param name="code">ISO 3166 code</param>
        /// <param name="ccTLD">Corresponding country code top-level domain.</param>
        /// <param name="calling">Country calling code</param>
        private Country(string name, string code, string ccTLD, ushort calling)
            : base(name)
        {
        }

        /// <summary>
        /// Official currency
        /// </summary>
        public Money Currency
        {
            get;
            set;
        }

        protected override Country[] Members
        {
            get { return _members; }
        }
    }
}