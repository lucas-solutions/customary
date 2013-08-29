using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Repositories;

    public class UnitDescriptor : TypeDescriptor
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