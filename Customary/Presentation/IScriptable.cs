using System.IO;

namespace Custom.Presentation
{
    public interface IScriptable
    {
        string[] Script { get; }
        void WriteTo(TextWriter writer);
        IScriptSerializer ToSerializer();
    }
}