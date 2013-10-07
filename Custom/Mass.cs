
namespace Custom
{
    public sealed class Mass : Measurement<Mass>
    {
        static Mass _default = Gram;
        static readonly Mass[] _members = GetMembers();

        public static Mass Default
        {
            get { return _default ?? (_default = Gram); }
            set { _default = value ?? Gram; }
        }

        public static implicit operator decimal(Mass weight)
        {
            return weight._grams;
        }

        public static readonly Mass Gram = new Mass("Gram", 1.0M);

        public static readonly Mass Kilogram = new Mass("Kilogram", 100M);

        private decimal _grams = Gram;

        public Mass()
            : base(null)
        {
            _grams = Gram;
        }

        private Mass(string name, decimal grams)
            : base(name)
        {
            _grams = grams;
        }

        protected override Mass[] Members
        {
            get { return _members; }
        }

        public decimal TotalGrams
        {
            get { return _grams; }
            set { _grams = value; }
        }

        public decimal TotalKilograms
        {
            get { return _grams / Kilogram; }
            set { _grams = value * Kilogram; }
        }
    }
}
