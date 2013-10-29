using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class ResultObject : Custom.Site.Presentation.ScriptObject
    {
        protected override string ContentType
        {
            get { return "application/json"; }
        }

        public object Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public int Total { get; set; }
    }

    public class ResultObject<T> : ResultObject
    {
        public new T Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}