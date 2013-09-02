using System;

namespace Custom.Utils.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class SignatureInfo
    {
        ///<summary>
        /// 
        ///</summary>
        public string Signature { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public string NormalizedUrl { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public string NormalizedRequestParameters { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public SignatureInfo()
        {
            NormalizedRequestParameters = string.Empty;
            NormalizedUrl = string.Empty;
            Signature = string.Empty;
        }
    }
}