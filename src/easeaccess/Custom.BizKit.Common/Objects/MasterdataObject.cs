using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    public class MasterdataObject : MetadataObject
    {
        private List<TextObject> _title;

        public string Name { get; set; }

        public List<TextObject> Title
        {
            get { return _title ?? (_title = new List<TextObject>()); }
            set { _title = value; }
        }
    }
}
