using System.IO;
using System.Web.Mvc;

namespace Custom.Presentation
{
    public interface IScriptable
    {
        bool IsEmpty { get; }
        string Template { get; set; }
        void Script(ScriptWriter writer);
    }
}