using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public enum StoreTypes
    {
        /// <summary>
        /// Raven Document
        /// </summary>
        Doument,

        /// <summary>
        /// Relational database table record
        /// </summary>
        Record,

        /// <summary>
        /// Relational database stored procedure.
        /// </summary>
        Procedure,

        /// <summary>
        /// Representational State Transfer (REST) JSON Service
        /// </summary>
        Restful,

        /// <summary>
        /// AJAX (GET and POST only) service. Each method has it's own enpoint
        /// </summary>
        Ajax,
    }
}