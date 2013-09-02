using System;
using System.Collections.Generic;

namespace Custom.Utils.Dropbox
{
    /// <summary>
    /// 
    /// </summary>
    public class GetDeltaCommand : DropboxCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public String Cursor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IDictionary<string, string> CreateParameters()
        {
            var d = new Dictionary<String, String>();
            d["cursor"] = this.Cursor;
            return d;
        }
    }
}
