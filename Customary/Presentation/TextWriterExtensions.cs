using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter writer, string[] lines)
        {
            if (lines != null && lines.Length > 0)
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
}