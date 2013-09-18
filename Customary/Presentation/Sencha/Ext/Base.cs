using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    [Description("Abstract base class that provides a common interface for publishing events")]
    public abstract partial class Base : ScriptObject
    {
        private Dictionary<string, string> _mixins;

        protected Base()
        {
        }

        public string Extend
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Dictionary<string, string> Mixins
        {
            get { return _mixins ?? (_mixins = new Dictionary<string,string>()); }
        }
    }
}