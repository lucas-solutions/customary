using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class ComponentObject
    {
        private string _name;

        public string Name
        {
            get { return _name ?? (_name = Guid.NewGuid().ToString().ToLower()); }
            set { _name = value.ToLower(); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}