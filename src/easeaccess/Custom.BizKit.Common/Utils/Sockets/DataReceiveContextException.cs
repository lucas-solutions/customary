using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Utils.Sockets
{
    using Custom.Exceptions;
    using Custom.Utils.Sockets.Internal;

    /// <summary>
    /// 
    /// </summary>
#if !NETFX_CORE
    [Serializable]
#endif
    public class DataTransferContextException : SocketClientException
    {
        /// <summary>
        /// 
        /// </summary>
        public DataTransferContext Context { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Text { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DataTransferContextException(DataTransferContext context)
        {
            this.Context = context;
            this.Text = this.Context.GetText();
        }
    }
}
