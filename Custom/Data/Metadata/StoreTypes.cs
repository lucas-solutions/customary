using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public enum StoreTypes
    {
        /// <summary>
        /// A method in a class will be invoked
        /// </summary>
        Computable,

        /// <summary>
        /// Raven Document Store
        /// </summary>
        Doument,

        /// <summary>
        /// Raven Embeddable Document Store
        /// </summary>
        Embeddable,

        /// <summary>
        /// Relational database table record
        /// </summary>
        Record,

        /// <summary>
        /// Relational database stored procedure.
        /// </summary>
        Procedural,

        /// <summary>
        /// Representational State Transfer (REST) JSON Service
        /// </summary>
        Restful,

        /// <summary>
        /// AJAX (GET and POST only) service. Each method has it's own endpoint
        /// </summary>
        Ajax,
    }
}