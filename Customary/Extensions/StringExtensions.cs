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
    }
}