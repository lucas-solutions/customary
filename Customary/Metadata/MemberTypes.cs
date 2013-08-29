using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    [DefaultValue(MemberTypes.Member)]
    public enum MemberTypes
    {
        Member,

        Primitive,

        Enum,

        Complex,

        Entity,

        Property,

        Method,

        Event,

        Constant,

        Constructor,

        /// <summary>
        /// Measurement Base Quantity
        /// </summary>
        Measure,


        /// <summary>
        /// Measurement Unit
        /// </summary>
        Unit,
    }
}