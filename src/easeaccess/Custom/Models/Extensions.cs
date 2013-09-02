using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public static class Extensions
    {
        const string Applications = @"Applications";
        const string Separator = @"/";
        const string Enums = @"Enums";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Grids = @"Grids";
        const string Links = @"Links";
        const string Models = @"Models";
        const string Notes = @"Notes";
        const string Operations = @"Operations";
        const string Pages = @"Pages";
        const string Reports = @"Reports";
        const string Screens = @"Screens";
        const string Jobs = @"Jobs";
        const string Tables = @"Tables";
        const string Tasks = @"Tasks";

        public static string DocumentSetName(this Application o)
        {
            return Applications;
        }

        public static string DocumentSetName(this Application document)
        {
            return Applications;
        }

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