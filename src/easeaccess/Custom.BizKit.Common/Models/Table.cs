using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    public class Table
    {
        private List<Column> _columns;

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<Column> Columns
        {
            get { return _columns ?? (_columns = new List<Column>()); }
            set { _columns = value; }
        }
    }
}
