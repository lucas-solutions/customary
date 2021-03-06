﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Utils
{
    /// <summary>
    /// 
    /// </summary>
#if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
#endif
    public class AsyncSocketCallErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public AsyncSocketCallErrorEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
    }
}
