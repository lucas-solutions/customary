using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Quantity is a property that can exist as a magnitude or multitude.
    /// Quantities can be compared in terms of "more", "less" or "equal", 
    /// or by assigning a numerical value in terms of a unit of measurement. 
    /// Quantity is among the basic classes of things along with quality, 
    /// substance, change, and relation. Being a fundamental term, quantity 
    /// is used to refer to any type of quantitative properties or attributes 
    /// of things. Some quantities are such by their inner nature (as number), 
    /// while others are functioning as states (properties, dimensions, attributes) 
    /// of things such as heavy and light, long and short, broad and narrow, 
    /// small and great, or much and little. 
    /// A small quantity is sometimes referred to as a quantulum.
    /// A physical quantity (or "physical magnitude") is a physical property 
    /// of a phenomenon, body, or substance, that can be quantified by measurement.
    /// </summary>
    public abstract class Quantity
    {
        public static implicit operator decimal(Quantity quantity)
        {
            return quantity.Amount;
        }

        public decimal Amount
        {
            get;
            set;
        }
    }

    [Data.Metadata.Complex("c45b4941-a935-4c4d-97bd-f15c5a0f2cc4")]
    public sealed class Quantity<TMeasurement> : Quantity
        where TMeasurement : Measurement<TMeasurement>
    {
        public TMeasurement Unit
        {
            get;
            set;
        }
    }
}
