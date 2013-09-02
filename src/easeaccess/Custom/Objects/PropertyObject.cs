using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class PropertyObject : ComponentObject
    {
        public string Default
        {
            get;
            set;
        }

        public string Convert
        {
            get;
            set;
        }

        public string Format
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }
    }
}