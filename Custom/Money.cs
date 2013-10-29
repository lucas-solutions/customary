using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public sealed class Money : Measurement<Money>
    {
        static Money _default = USD;
        static readonly Money[] _members = GetMembers();

        public static Money Default
        {
            get { return _default ?? (_default = USD); }
            set { _default = value ?? USD; }
        }

        public static implicit operator decimal(Money money)
        {
            return money._value;
        }

        [Data.Metadata.Unit(Name = "", IsSuffix = true)]
        public static readonly Money CRC = new Money("CRC", USD / 512);

        [Data.Metadata.Unit(Name = "", IsSuffix = true)]
        public static readonly Money CUC = new Money("CUC", USD);

        [Data.Metadata.Unit(Name = "", IsSuffix = true)]
        public static readonly Money CUP = new Money("CUP", CUC / 25);

        [Data.Metadata.Unit(Name = "British pound", Sign = "£", IsSuffix = true)]
        public static readonly Money GBP = new Money("GBP", 1);

        [Data.Metadata.Unit(Name = "Euro", Sign = "$", IsSuffix = true)]
        public static readonly Money EUR = new Money("EUR", USD);

        [Data.Metadata.Unit(Name = "United States dollar", Sign = "€", IsSuffix = true)]
        public static readonly Money USD = new Money("USD", 1);

        private decimal _value;

        public Money()
            : base(null)
        {
            _value = 0;
        }

        private Money(string name, decimal value)
            : base(name)
        {
            _value = value;
        }

        protected override Money[] Members
        {
            get { return _members; }
        }

        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
