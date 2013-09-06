using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.ExtJs
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

        public override void Write(TextWriter writer)
        {
            if (_convert != null)
            {
                writer.WriteLine("{");
                writer.WriteLine("name: '" + _name + "'");
                writer.WriteLine("type: '" + _type + "'");
                writer.WriteLine("convert: function(inches) {");
                writer.WriteLine("return Math.round(inches * 2.54);");
                writer.WriteLine("}");
                writer.Write("}");
            }
            else if (_type != "string")
            {
                writer.Write("{ name: '" + _name + "', type: '" + _type + "' }");
            }
            else
            {
                writer.Write("'" + _name + "'");
            }
        }
    }
}