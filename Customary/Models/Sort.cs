using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class Sort
    {
        public string Property
        {
            get;
            set;
        }

        public SortDirection Direction
        {
            get;
            set;
        }
    }
}