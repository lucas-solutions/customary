using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    using Dictionary = Dictionary<string, object>;

    public class WorkerObject
    {
        public string Status
        {
            get;
            set;
        }

        public string Task
        {
            get;
            set;
        }

        public Dictionary Result
        {
            get;
            set;
        }

        public List<string> Messages
        {
            get;
            set;
        }
    }
}