using System;
using System.Collections.Generic;

namespace Custom.Utils.OAuth
{
    /// <summary>
    /// Provides a predefined set of algorithms that are supported officially by the protocol
    /// </summary>
    public enum OAuthSignatureTypes
    {
        /// <summary>
        /// 
        /// </summary>
        HMACSHA1,
        /// <summary>
        /// 
        /// </summary>
        PLAINTEXT,
        /// <summary>
        /// 
        /// </summary>
        RSASHA1,
    }
}