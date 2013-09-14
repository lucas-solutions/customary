using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public partial class ScriptFunction : Scriptable
    {
        protected override IScriptSerializer ToNativeSerializer()
        {
            return ToSerializer();
        }
    }
}