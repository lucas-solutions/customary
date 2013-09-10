using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class Validation
    {
        public JObject<Field> Field
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
        public void WriteTo(ScriptWriter writer)
        {
            writer.Write("{");
            writer.WriteLine();
            writer.Write("}");
        }
    }
}