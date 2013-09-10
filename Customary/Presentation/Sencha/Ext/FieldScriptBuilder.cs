using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Custom.Metadata;

    public class FieldScriptBuilder : ScriptBuilder
    {
        public string _name;
        public string _type;
        public string _default;
        public Action<TextWriter> _convert;

        public FieldScriptBuilder()
        {
        }

        public FieldScriptBuilder(PropertyDescriptor property)
        {
        }

        public FieldScriptBuilder Name(string value)
        {
            _name = value;
            return this;
        }

        public FieldScriptBuilder Type(string value)
        {
            _type = value;
            return this;
        }

        public FieldScriptBuilder Default(string value)
        {
            _default = value;
            return this;
        }

        public FieldScriptBuilder Convert(Action<System.IO.TextWriter> value)
        {
            _convert = value;
            return this;
        }
    }
}