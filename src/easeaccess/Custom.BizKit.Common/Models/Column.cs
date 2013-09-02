using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class Column
    {
        private List<Text> _title;

        public string Name
        {
            get;
            set;
        }

        public List<Text> Title
        {
            get { return _title ?? (_title = new List<Text>()); }
            set { _title = value; }
        }

        public int? Flex
        {
            get;
            set;
        }

        public bool? Fixed
        {
            get;
            set;
        }

        public int? Width
        {
            get;
            set;
        }
    }
}