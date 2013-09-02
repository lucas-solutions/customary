using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class FormObject : ResourceObject
    {
        public string Model
        {
            get;
            set;
        }

        public List<FieldObject> Fields
        {
            get;
            set;
        }
    }
}