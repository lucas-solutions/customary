using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public static class ListExtensions
    {
        public static void Add(this List<string> lines)
        {
            lines.Add(string.Empty);
        }

        public static void Append(this List<string> lines, char c)
        {
            if (lines.Count > 0)
                lines[lines.Count - 1] = lines[lines.Count - 1] + c;
            else
                lines.Add(c.ToString());
        }

        public static void Append(this List<string> lines, string s)
        {
            if (lines.Count > 0)
                lines[lines.Count - 1] = lines[lines.Count - 1] + s;
            else
                lines.Add(s);
        }

        public static void Append(this List<string> lines, IEnumerable<string> block, string indent)
        {
            lines.Append(block.FirstOrDefault());
            lines.AddRange(block.Skip(1).Select(s => indent + s));
        }

        public static bool EndsWith(this List<string> lines, char c)
        {
            if (lines == null || lines.Count.Equals(0))
                return false;

            var last = lines[lines.Count - 1];

            return string.IsNullOrEmpty(last) ? false : last[last.Length - 1].Equals(c);
        }

        public static void TrimEnd(this List<string> lines, char c)
        {
            lines[lines.Count - 1] = lines[lines.Count - 1].TrimEnd(c);
        }

        public static void Write(this List<string> lines, TextWriter writer)
        {
            if (lines != null && lines.Count > 0)
            {
                for (var i = 0; i < lines.Count - 1; i++)
                    writer.WriteLine(lines[i]);
                writer.Write(lines[lines.Count - 1]);
            }
        }
    }
}