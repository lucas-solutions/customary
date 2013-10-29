using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public static class TextWriterExtensions
    {
        public static void WriteAllLines(this TextWriter writer, List<string> lines)
        {
            if (lines != null && lines.Count > 0)
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
}