using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public partial class ScriptFunction : IScriptable
    {
        string[] IScriptable.Script
        {
            get { return Render(); }
        }

        private string[] Render()
        {
            var serializer = ToSerializer();
            return serializer.Render();
        }

        void IScriptable.WriteTo(System.IO.TextWriter writer)
        {
            writer.Write(Render());
        }

        IScriptSerializer IScriptable.ToSerializer()
        {
            return ToSerializer();
        }
    }
}