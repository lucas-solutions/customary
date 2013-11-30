using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Minifiers
{
    /// <summary>
    /// Interface for compression classes
    /// </summary>
    public interface ICompress
    {
        /// <summary>
        /// Method to compress script
        /// </summary>
        /// <param name="script">script to compress</param>
        /// <returns>compressed script string</returns>
        string Compress(string script);
    }
}