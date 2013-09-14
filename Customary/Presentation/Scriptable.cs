using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public abstract partial class Scriptable : IScriptable
    {
        protected abstract IScriptSerializer ToNativeSerializer();

        IScriptSerializer IScriptable.ToSerializer()
        {
            return ToNativeSerializer();
        }
    }
}