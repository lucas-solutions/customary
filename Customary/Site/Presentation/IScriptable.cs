using System.Collections.Generic;
using System.IO;

namespace Custom.Site.Presentation
{
    public interface IScriptable
    {
        void Render(List<string> lines);

        void Write(TextWriter writer);
    }
}