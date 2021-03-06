﻿using System;
using System.Collections.Generic;

namespace Custom.Utils.Dropbox
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCommand : DropboxCommand
    {
        private RootFolder _root = RootFolder.Dropbox;
        private String _path = "";

        /// <summary>
        /// 
        /// </summary>
        public RootFolder Root
        {
            get { return _root; }
            set { _root = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IDictionary<string, string> CreateParameters()
        {
            var d = new Dictionary<String, String>();
            d["root"] = this.Root.ToString().ToLower();
            d["path"] = this.Path;
            return d;
        }
    }
}
