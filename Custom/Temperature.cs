using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    [Metadata.Enum("fa7ecaba-b191-4a2d-b2fc-4b5339857ecb")]
    public sealed class Temperature : Measurement<Temperature>
    {
        static Temperature _default = Kelvin;
        static readonly Temperature[] _members = GetMembers();

        public static Temperature Default
        {
            get { return _default ?? (_default = Kelvin); }
            set { _default = value ?? Kelvin; }
        }

        public static implicit operator decimal(Temperature temperature)
        {
            return temperature._kelvins;
        }

        [Metadata.Unit(Suffix = "°C")]
        public static readonly Temperature Celsius = new Temperature("Celsius", Kelvin - 273.15M);

        [Metadata.Unit(Suffix = "°F")]
        public static readonly Temperature Fahrenheit = new Temperature("Fahrenheit", Celsius * 9 / 5 + 32M);

        [Metadata.Unit(Suffix = "K")]
        public static readonly Temperature Kelvin = new Temperature("Kelvin", 1);

        [Metadata.Unit(Suffix = "°R")]
        public static readonly Temperature Rankine = new Temperature("Rankine", Kelvin * 9 / 5);

        [Metadata.Unit(Suffix = "°De")]
        public static readonly Temperature Delisle = new Temperature("Delisle", (100M - Celsius) * 3 / 2);

        [Metadata.Unit(Suffix = "°N")]
        public static readonly Temperature Newton = new Temperature("Newton", Celsius * 33 / 100);

        [Metadata.Unit(Name = "Réaumur", Suffix = "°Ré")]
        public static readonly Temperature Reaumur = new Temperature("Reaumur", Celsius * 4 / 5);

        [Metadata.Unit(Name = "Rømer", Suffix = "°Rø")]
        public static readonly Temperature Romer = new Temperature("Romer", Celsius * 21 / 40 + 7.5M);

        // I choose Keilvin because 0K is the absolute zero
        private decimal _kelvins;

        public Temperature()
            : base(null)
        {
            // absolute zero
            _kelvins = 0;
        }

        private Temperature(string name, decimal kelvins)
            : base(name)
        {
            _kelvins = kelvins;
        }

        protected override Temperature[] Members
        {
            get { return _members; }
        }

        public decimal TotalCelsius
        {
            get { return _kelvins - 273.15M; }
            set { _kelvins = value + 273.15M; }
        }

        public decimal TotalFahrenheit
        {
            get { return _kelvins * 9 / 5 - 459.67M; }
            set { _kelvins = (value + 459.67M) * 5 / 9; }
        }

        public decimal TotalRakine
        {
            get { return _kelvins * 9 / 5; }
            set { _kelvins = value * 5 / 9; }
        }

        public decimal TotalDelisle
        {
            get { return (373.15M - _kelvins) * 3 / 2; }
            set { _kelvins = 373.15M - value * 2 / 3; }
        }

        public decimal TotalNewton
        {
            get { return (_kelvins - 273.15M) * 33 / 100; }
            set { _kelvins = value * 100 / 33 + 273.15M; }
        }

        public decimal TotalReaumur
        {
            get { return (_kelvins - 273.15M) * 4 / 5; }
            set { _kelvins = value * 5 / 4 + 273.15M; }
        }

        public decimal TotalRomer
        {
            get { return (_kelvins - 273.15M) * 21 / 40 + 7.5M; }
            set { _kelvins = (value - 7.5M) * 40 / 21 + 273.15M; }
        }
    }
}
