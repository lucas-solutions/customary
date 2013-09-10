using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.grid.column
{
    public class ColumnCollection
    {
        private Dictionary<string, object> _defaults;
        private List<Column> _items;

        public List<Column> Items
        {
            get { return _items ?? (_items = new List<Column>()); }
        }

        public Dictionary<string, object> Defaults
        {
            get { return _defaults ?? (_defaults = new Dictionary<string, object>()); }
        }
    }
}