using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.ExtJs
{
    using Custom.Metadata;

    public class ValidationScriptBuilder : ScriptBuilder
    {
        private string _presence;
        private string _format;
        private int? _length;
        private string _custom;

        public ValidationScriptBuilder()
        {
        }

        public ValidationScriptBuilder(PropertyDescriptor property)
        {
        }

        public ValidationScriptBuilder(string fieldName, PrimitiveDescriptor type)
        {
        }

        public ValidationScriptBuilder(string fieldName, EnumDescriptor type)
        {
        }

        public ValidationScriptBuilder(string fieldName, UnitDescriptor type)
        {
        }

        public ValidationScriptBuilder Presence(string value)
        {
            _presence = value;
            return this;
        }

        public ValidationScriptBuilder Format(string value)
        {
            _format = value;
            return this;
        }

        public ValidationScriptBuilder Length(int value)
        {
            _length = value;
            return this;
        }

        public ValidationScriptBuilder Custom(string value)
        {
            _custom = value;
            return this;
        }

        public override void Write(TextWriter writer)
        {
            writer.Write("{");
            writer.WriteLine();
            writer.Write("}");
        }
    }
}