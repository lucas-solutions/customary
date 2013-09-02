using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class Item
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

        public string Value
        {
            get;
            set;
        }
    }
}