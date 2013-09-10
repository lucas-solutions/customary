using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public interface IScriptSerializer
    {
        TSerializer Cast<TSerializer>() where TSerializer : class, IScriptSerializer;
        void Serialize(ScriptWriter writer);
    }

    public interface IScriptSerializer<TModel>
        where TModel : Scriptable
    {
        TModel ToModel();
    }
}