using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    [DefaultValue(MemberTypes.Constant)]
    public enum MemberTypes : byte
    {
        /// <summary>
        /// Constant value
        /// </summary>
        Constant = 0x00,

        /// <summary>
        /// Represents an Enum member
        /// </summary>
        Member = 0x01,

        /// <summary>
        /// Represents the field that will actually store the data
        /// </summary>
        Property = 0x02,

        /// <summary>
        /// Business procedure.
        /// </summary>
        Method = 0x03,

        /// <summary>
        /// Initializer method.
        /// </summary>
        Constructor = 0x04,

        /// <summary>
        /// Method invoked by user action.
        /// </summary>
        Event = 0x05,
        
        /// <summary>
        /// Value: int, string, email, etc.
        /// </summary>
        Value = 0x8,

        /// <summary>
        /// Lists with values
        /// </summary>
        Enum = 0x9,

        /// <summary>
        /// Unit of Measurement.
        /// </summary>
        Unit = 0xA,

        /// <summary>
        /// Text is like an Unit, but instead of measure it is qualified by a culture.
        /// </summary>
        Text = 0xB,

        /// <summary>
        /// Model with properties.
        /// </summary>
        Model = 0xC
    }
}