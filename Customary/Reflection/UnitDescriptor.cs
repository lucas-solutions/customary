using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Reflection
{
    using Custom.Documents;

    public class UnitDescriptor : BusinessType
    {
        public double Factor { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public string Symbol { get; set; }

        // ex: Time, Mass, Length, Temperature, ElectricCurrent, Money, LuminousIntensity, AmountOfSubstance
        public string Measure { get; set; }

        // base unit ex: Second, Gram
        public string Base { get; set; }
    }
}