using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class AreaObject : ComponentObject
    {
        private List<AreaObject> _areas;

        public List<AreaObject> Areas
        {
            get { return _areas ?? (_areas = new List<AreaObject>()); }
            set { _areas = value; }
        }

        public string Resource
        {
            get;
            set;
        }
    }
}