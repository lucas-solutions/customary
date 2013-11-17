using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public class ValidationDefinition : BaseDefinition
    {
        public string List
        {
            get;
            set;
        }

        public string Matcher
        {
            get;
            set;
        }

        public int? Max
        {
            get;
            set;
        }

        public int? Min
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }
    }
}
