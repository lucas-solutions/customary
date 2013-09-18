using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class StringExtensions
    {
        public static string PascalCase(this string s)
        {
            if (s == null)
                return null;

            if (s.Length == 0)
                return s;

            return char.ToUpper(s[0]) + s.Substring(1, s.Length - 1).ToLower();
        }

        public static string CamelCase(this string s)
        {
            if (s == null)
                return null;

            if (s.Length == 0 || !char.IsUpper(s[0]))
                return s;

            int len;
            for (len = 0; len < s.Length && char.IsUpper(s[len]); len++);

            return len > 0 ? s.Substring(0, len).ToLower() + s.Substring(len) : s;
        }
    }
}