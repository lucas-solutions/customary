using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public partial class Field : Base
    {
        private Builder _builder;

        public JFunction Convert
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

        public JFunction SortType
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public bool UseNulls
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder());
        }

        protected override IScriptSerializer CreateSerializer()
        {
            return new Serializer(this);
        }
    }
}