using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public sealed class Length : Measurement<Length>
    {
        static Length _default = Metre;
        static readonly Length[] _members = GetMembers();

        public static Length Default
        {
            get { return _default ?? (_default = Metre); }
            set { _default = value ?? Metre; }
        }

        public static implicit operator decimal(Length length)
        {
            return length._metres;
        }

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Yoctometre = new Length("Yoctometre", 10e-24M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Zeptometre = new Length("Zeptometre", 10e-21M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Attometre = new Length("Attometre", 10e-18M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Femtometre = new Length("Femtometre", 10e-15M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Picometre = new Length("Picometre", 10e-12M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Nanometre = new Length("Nanometre", 10e-9M * Metre);

        [Data.Metadata.Unit(Suffix = "µm")]
        public static readonly Length Micrometre = new Length("Micrometre", 10e-6M * Metre);

        [Data.Metadata.Unit(Suffix = "mm")]
        public static readonly Length Milimetre = new Length("Milimetre", 10e-3M * Metre);

        [Data.Metadata.Unit(Suffix = "cm")]
        public static readonly Length Centimetre = new Length("Centimetre", 10e-2M * Metre);

        [Data.Metadata.Unit(Suffix = "dm")]
        public static readonly Length Decimetre = new Length("Decimetre", 10e-1M * Metre);

        [Data.Metadata.Unit(Suffix = "m")]
        public static readonly Length Metre = new Length("Metre", 1M);

        [Data.Metadata.Unit(Suffix = "dam")]
        public static readonly Length Decametre = new Length("Decametre", 10e1M * Metre);

        [Data.Metadata.Unit(Suffix = "hm")]
        public static readonly Length Hectometre = new Length("Hectometre", 10e2M * Metre);

        [Data.Metadata.Unit(Suffix = "km")]
        public static readonly Length Kilometre = new Length("Kilometre", 10e3M * Metre);

        [Data.Metadata.Unit(Suffix = "Mm")]
        public static readonly Length Megametre = new Length("Megametre", 10e6M * Metre);

        [Data.Metadata.Unit(Suffix = "Gm")]
        public static readonly Length Gigametre = new Length("Gigametre", 10e9M * Metre);

        [Data.Metadata.Unit(Suffix = "Tm")]
        public static readonly Length Terametre = new Length("Terametre", 10e12M * Metre);

        [Data.Metadata.Unit(Suffix = "Pm")]
        public static readonly Length Petametre = new Length("Petametre", 10e15M * Metre);

        [Data.Metadata.Unit(Suffix = "Em")]
        public static readonly Length Exametre = new Length("Exametre", 10e18M * Metre);

        [Data.Metadata.Unit(Suffix = "Zm")]
        public static readonly Length Zettametre = new Length("Zettametre", 10e21M * Metre);

        [Data.Metadata.Unit(Suffix = "Ym")]
        public static readonly Length Yottametre = new Length("Yottametre", 10e24M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Yard = new Length("Yard", 0.9144M * Metre);

        [Data.Metadata.Unit(Suffix = "")]
        public static readonly Length Inch = new Length("Inch", 0.0254M * Metre);

        private decimal _metres = Metre;

        private Length()
            : base(null)
        {
        }

        private Length(string name, decimal metres)
            : base(name)
        {
            _metres = metres;
        }

        protected override Length[] Members
        {
            get { return _members; }
        }

        public decimal TotalCentimetres
        {
            get { return _metres / Centimetre; }
            set { _metres = value * Centimetre; }
        }

        public decimal TotalDecimetres
        {
            get { return _metres / Decimetre; }
            set { _metres = value * Decimetre; }
        }

        public decimal TotalInches
        {
            get { return _metres / Inch; }
            set { _metres = value * Inch; }
        }

        public decimal TotalMetres
        {
            get { return _metres; }
            set { _metres = value; }
        }

        public decimal TotalMilimetres
        {
            get { return _metres / Milimetre; }
            set { _metres = value * Milimetre; }
        }

        public decimal TotalKilometres
        {
            get { return _metres / Kilometre; }
            set { _metres = value * Kilometre; }
        }

        public decimal TotalYards
        {
            get { return _metres / Yard; }
            set { _metres = value * Yard; }
        }
    }
}
