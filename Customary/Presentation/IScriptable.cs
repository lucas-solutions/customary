using System.Collections.Generic;
using System.IO;

namespace Custom.Presentation
{
    public interface IScriptable
    {
        void Render(List<string> lines);

        void Write(TextWriter writer);
    }
}