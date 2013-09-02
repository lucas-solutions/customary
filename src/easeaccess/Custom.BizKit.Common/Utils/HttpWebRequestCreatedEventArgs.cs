using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Custom.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpWebRequestCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpWebRequest HttpWebRequest { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public HttpWebRequestCreatedEventArgs(HttpWebRequest request)
        {
            this.HttpWebRequest = request;
        }
    }
}
