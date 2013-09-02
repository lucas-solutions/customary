using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    using Dictionary = Dictionary<string, object>;

    public class TaskObject : ComponentObject
    {
        public string Operation
        {
            get;
            set;
        }

        public Dictionary Input
        {
            get;
            set;
        }
    }
}