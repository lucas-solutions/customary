using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public enum EntityStoreTypes
    {
        /// <summary>
        /// Raven Document
        /// </summary>
        Singleton,

        /// <summary>
        /// Raven Document
        /// </summary>
        Metadata,

        /// <summary>
        /// Relational database table
        /// </summary>
        RelationalTable,

        /// <summary>
        /// Relational database stored procedure.
        /// </summary>
        StoredProcedure,

        /// <summary>
        /// Representational State Transfer (REST) JSON Service
        /// </summary>
        RestfulService,

        /// <summary>
        /// Create, read, update and delete (CRUD) JSON Service
        /// </summary>
        CrudService,
    }
}