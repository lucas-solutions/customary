using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    /// <summary>
    /// This class is a base for all id generators. It also provides lookup of id generators by their id.
    /// </summary>
    public abstract class IdGenerator : ScriptObject
    {
        /// <summary>
        /// The id by which to register a new instance. This instance can be found using the get static method.
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// The string to place in front of the sequential number for each generated id. The default is blank.
        /// </summary>
        [DefaultValue("")]
        public string Prefix
        {
            get;
            set;
        }

        /// <summary>
        /// The number at which to start generating sequential id's.
        /// </summary>
        [DefaultValue(1)]
        public int Seed
        {
            get;
            set;
        }

        /// <summary>
        /// Id generator type
        /// </summary>
        public Types Type
        {
            get;
            set;
        }

        public enum Types
        {
            /// <summary>
            /// Sequential id generator
            /// </summary>
            Sequential,

            /// <summary>
            /// UUID's according to RFC 4122.
            /// </summary>
            UUID
        }
    }
}