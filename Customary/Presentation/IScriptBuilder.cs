using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public interface IScriptBuilder
    {
        TBuilder Cast<TBuilder>() where TBuilder : class, IScriptBuilder;
    }

    public interface IScriptBuilder<TObject>
        where TObject : Scriptable
    {
        void Render(Scriptable obj);
        TObject ToModel();
    }
}