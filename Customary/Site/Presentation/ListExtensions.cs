using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public static class ListExtensions
    {
        public static void Add(this List<string> lines)
        {
            lines.Add(string.Empty);
        }

        public static void Add(this List<string> lines, char c)
        {
            lines.Add(c.ToString());
        }

        public static void Add(this List<string> lines, char c, string indent)
        {
            lines.Add(indent + c.ToString());
        }

        public static void Add(this List<string> lines, string s, string indent)
        {
            lines.Add(indent + s);
        }

        public static void Add(this List<string> lines, List<string> block, string indent)
        {
            foreach (var line in block)
                lines.Add(indent + line);
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

        public static void TrimLeft(this List<string> lines)
        {
            TrimLeft(lines, 0, lines.Count);
        }

        public static void TrimLeft(this List<string> lines, int first, int count)
        {
            if (lines != null && lines.Count > 0)
            {
                int minPadding = int.MaxValue;
                for (int i = first; i < first + count; i++)
                {
                    var line = lines[i];

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    int leftPadding;
                    for (leftPadding = 0; leftPadding < line.Length && minPadding > leftPadding && char.IsWhiteSpace(line, leftPadding); leftPadding++) ;

                    if (minPadding > leftPadding && leftPadding < line.Length)
                        minPadding = leftPadding;

                    if (minPadding.Equals(0))
                        break;
                }

                if (minPadding > 0)
                {
                    for (int i = first; i < first + count; i++)
                    {
                        var line = lines[i];

                        if (string.IsNullOrWhiteSpace(line))
                            lines[i] = string.Empty;
                        else
                            lines[i] = line.Substring(minPadding);
                    }
                }
            }
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