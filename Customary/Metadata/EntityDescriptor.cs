using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public class EntityDescriptor : ComplexDescriptor
    {
        /// <summary>
        /// Name of the identity property
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Name of the default text property
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Is masterdata? If not it is transactional data.
        /// </summary>
        public bool Masterdata { get; set; }

        /// <summary>
        /// Uses calls to stored procedure in to perform SELECT, INSERT, UPDATE or DELETE.
        /// If not set, SQL statements are used with ADO directly.
        /// </summary>
        public bool Transactional { get; set; }

        /// <summary>
        /// SQL mapping for a given table name.
        /// </summary>
        public Dictionary<string, TableMapping> Mapping { get; set; }
    }
}