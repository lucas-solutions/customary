using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class MemberObject
    {
        private string _name;
        private string _value;

        public string Name
        {
            get { return _name ?? (_name = Guid.NewGuid().ToString("s")); }
            set { _name = value; }
        }

        public string Value
        {
            get { return _value ?? (_value = Name); }
            set { _value = value; }
        }

        public override string ToString()
        {
            return "\"" + Name + "\": \"" + Value + "\"";
        }
    }
}