using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class GridObject : ResourceObject
    {
        public List<ColumnObject> Columns
        {
            get;
            set;
        }
    }
}