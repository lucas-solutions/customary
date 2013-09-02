using System;
using System.Collections.Generic;

namespace Custom.Utils.Dropbox
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccountCommand : DropboxCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IDictionary<string, string> CreateParameters()
        {
            var d = new Dictionary<String, String>();
            return d;
        }
    }
}
