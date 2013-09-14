using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Custom.Presentation
{
    partial class ScriptFunction
    {
        private Serializer _serializer;

        public Serializer ToSerializer()
        {
            return _serializer ?? (_serializer = new Serializer(this));
        }

        public class Serializer : Scriptable.Serializer
        {
            private ScriptFunction _fn;

            public Serializer(ScriptFunction fn)
            {
                _fn = fn;
            }

            public ScriptFunction ToFuncion()
            {
                return _fn;
            }
        }
    }
}