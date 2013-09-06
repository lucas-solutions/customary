using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.ExtJs
{
    public class ProxyScriptBuilder : ScriptBuilder
    {
        private string _type;
        private string _url;

        public ProxyScriptBuilder Type(string type)
        {
            _type = type;
            return this;
        }

        public ProxyScriptBuilder Url(string url)
        {
            _url = url;
            return this;
        }

        public override void Write(TextWriter writer)
        {
            writer.Write("{");
            writer.WriteLine();
            writer.Write("type: " + _type);
            writer.Write(',');
            writer.WriteLine();
            writer.Write("url: " + _url);
            writer.WriteLine();
            writer.Write("}");
        }
    }
}