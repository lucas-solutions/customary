using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class ResourceObject : ComponentObject
    {
        private TextObject _title;
        private TextObject _summary;
        private int _version = 1;

        public TextObject Title
        {
            get { return _title ?? (_title = new TextObject()); }
            set { _title = value; }
        }

        public TextObject Summary
        {
            get { return _summary ?? (_summary = new TextObject()); }
            set { _summary = value; }
        }

        public int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public override string ToString()
        {
            return Name + ".v" + _version;
        }
    }
}