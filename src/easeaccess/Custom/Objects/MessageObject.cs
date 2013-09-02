using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class MessageObject
    {
        /// <summary>
        /// Http Code
        /// </summary>
        public int Code
        {
            get;
            set;
        }

        /// <summary>
        /// Where did it happen
        /// </summary>
        public string Where
        {
            get;
            set;
        }

        /// <summary>
        /// What happened
        /// </summary>
        public string What
        {
            get;
            set;
        }

        /// <summary>
        /// Why did it happend
        /// </summary>
        public string Why
        {
            get;
            set;
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Text
        {
            get;
            set;
        }
    }
}