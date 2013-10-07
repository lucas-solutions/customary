using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public sealed class EntityDescriptor : ObjectDescriptor
    {
        /// <summary>
        /// Is singleton?
        /// </summary>
        [Obsolete("Use Store.Type")]
        public bool Singleton { get; set; }

        /// <summary>
        /// Is masterdata? If not it is transactional data.
        /// </summary>
        [Obsolete("Use Store.Type")]
        public bool Masterdata { get; set; }

        /// <summary>
        /// Uses calls to stored procedure in to perform SELECT, INSERT, UPDATE or DELETE.
        /// If not set, SQL statements are used with ADO directly.
        /// </summary>
        [Obsolete("Use Store.Type")]
        public bool Transactional { get; set; }

        /// <summary>
        /// Document name, table name, REST (Representational state transfer) service URL.
        /// </summary>
        public EntityStore Store { get; set; }
    }
}