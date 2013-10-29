using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data
{
    public partial class Field : ScriptObject
    {
        public ScriptFunction Convert
        {
            get;
            set;
        }

        public string DateFormat
        {
            get;
            set;
        }

        public string DefaultValue
        {
            get;
            set;
        }

        public string Mapping
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool Persist
        {
            get;
            set;
        }

        public string SortDir
        {
            get;
            set;
        }

        public ScriptFunction SortType
        {
            get;
            set;
        }

        [DefaultValue("string")]
        public string Type
        {
            get;
            set;
        }

        [DefaultValue(true)]
        public bool UseNulls
        {
            get;
            set;
        }
    }
}