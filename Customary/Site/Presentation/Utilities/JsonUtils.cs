using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Utilities
{
    using System.Globalization;
    using System.Text;

    public class JsonUtils
    {
        public static string Enquote(string s)
        {
            if ((s == null) || (s.Length == 0))
            {
                return "\"\"";
            }
            int length = s.Length;
            StringBuilder builder = new StringBuilder(length + 4);
            builder.Append('"');
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                switch (ch)
                {
                    case '\\':
                    case '"':
                    case '>':
                        builder.Append('\\');
                        builder.Append(ch);
                        break;

                    case '\b':
                        builder.Append(@"\b");
                        break;

                    case '\t':
                        builder.Append(@"\t");
                        break;

                    case '\n':
                        builder.Append(@"\n");
                        break;

                    case '\f':
                        builder.Append(@"\f");
                        break;

                    case '\r':
                        builder.Append(@"\r");
                        break;

                    default:
                        if (ch < ' ')
                        {
                            string str2 = new string(ch, 1);
                            string str = "000" + int.Parse(str2, NumberStyles.HexNumber);
                            builder.Append(@"\u" + str.Substring(str.Length - 4));
                        }
                        else
                        {
                            builder.Append(ch);
                        }
                        break;
                }
            }
            builder.Append('"');
            return builder.ToString();
        }
    }
}