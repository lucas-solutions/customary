using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    public class GridObject : MasterdataObject
    {
        private List<ColumnObject> _columns;

        public List<ColumnObject> Columns
        {
            get { return _columns ?? (_columns = new List<ColumnObject>()); }
            set { _columns = value; }
        }
    }
}
