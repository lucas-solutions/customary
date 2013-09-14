using System.IO;

namespace Custom.Presentation
{
    public interface IScriptable
    {
        IScriptSerializer ToSerializer();
    }
}