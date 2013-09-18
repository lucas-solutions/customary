using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class Validations : ScriptObject
    {
        private Builder _builder;

        public ScriptField<Field> Field
        {
            get;
            set;
        }

        public int? Min
        {
            get;
            set;
        }

        public string[] List
        {
            get;
            set;
        }

        public string Matcher
        {
            get;
            set;
        }

        public ValidationTypes Type
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        protected override Scriptable ToScriptable()
        {
            return ToBuilder();
        }

        public class Builder : Builder<Validations, Builder>
        {
            public Builder(Validations model)
                : base(model)
            {
            }
        }
    }
}