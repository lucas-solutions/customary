using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    public class AreaObject : ServiceObject
    {
        private List<AreaObject> _areas;

        public List<AreaObject> Areas
        {
            get { return _areas ?? (_areas = new List<AreaObject>()); }
            set { _areas = value; }
        }
    }
}
