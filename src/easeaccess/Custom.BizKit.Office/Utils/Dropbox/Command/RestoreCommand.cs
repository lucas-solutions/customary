﻿using System;
using System.Collections.Generic;

namespace Custom.Utils.Dropbox
{
    /// <summary>
    /// 
    /// </summary>
    public class RestoreCommand : DropboxCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public RootFolder Root { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Rev { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RestoreCommand()
        {
            Root = RootFolder.Dropbox;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IDictionary<string, string> CreateParameters()
        {
            var d = new Dictionary<String, String>();
            d["rev"] = this.Rev;
            return d;
        }
    }
}
