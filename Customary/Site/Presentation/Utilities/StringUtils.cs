using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    public static class StringUtils
    {
        private static readonly Random random = new Random();

        public static string Base64Decode(this string text)
        {
            System.Text.Decoder decoder = new UTF8Encoding().GetDecoder();
            byte[] bytes = Convert.FromBase64String(text);
            char[] chars = new char[decoder.GetCharCount(bytes, 0, bytes.Length)];
            decoder.GetChars(bytes, 0, bytes.Length, chars, 0);
            return new string(chars);
        }

        public static string Base64Encode(this string text)
        {
            byte[] buffer = new byte[text.Length];
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        [Description("Return a sub array of this string array.")]
        public static string Between(this string text, string start, string end)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return text.RightOf(start).LeftOfRightmostOf(end);
        }

        public static string Chop(this string text)
        {
            return text.Chop(1);
        }

        public static string Chop(this string text, int characters)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return text.Substring(characters, (text.Length - characters) - 1);
        }

        public static string Chop(this string text, string character)
        {
            if (!text.IsEmpty() && (text.StartsWith(character) && text.EndsWith(character)))
            {
                int length = character.Length;
                return text.Substring(length, text.Length - (length + 1));
            }
            return text;
        }

        public static string ConcatWith(this string instance, string text)
        {
            return (instance + text);
        }

        public static string ConcatWith(this string instance, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(string.Format("The args parameter can not be null when calling {0}.Format().", instance));
            }
            return (instance + string.Concat(args));
        }

        public static bool Contains(this string instance, params string[] args)
        {
            foreach (string str in args)
            {
                if (instance.Contains(str))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Ellipsis(this string text, int length)
        {
            return text.Ellipsis(length, false);
        }

        public static string Ellipsis(this string text, int length, bool word)
        {
            if ((text == null) || (text.Length <= length))
            {
                return text;
            }
            if (word)
            {
                string str = text.Substring(0, length - 2);
                int num = Math.Max(str.LastIndexOf(' '), Math.Max(str.LastIndexOf('.'), Math.Max(str.LastIndexOf('!'), str.LastIndexOf('?'))));
                if ((num != -1) && (num >= (length - 15)))
                {
                    return (str.Substring(0, num) + "...");
                }
            }
            return (text.Substring(0, length - 3) + "...");
        }

        public static string Enquote(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            int length = text.Length;
            StringBuilder builder = new StringBuilder(length + 4);
            for (int i = 0; i < length; i++)
            {
                char ch = text[i];
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
                            string s = new string(ch, 1);
                            string str = "000" + int.Parse(s, NumberStyles.HexNumber);
                            builder.Append(@"\u" + str.Substring(str.Length - 4));
                        }
                        else
                        {
                            builder.Append(ch);
                        }
                        break;
                }
            }
            return builder.ToString();
        }

        public static string EnsureSemiColon(this string text)
        {
            if (!text.IsEmpty() && (!string.IsNullOrEmpty(text) && !text.EndsWith(";")))
            {
                return (text + ";");
            }
            return text;
        }

        private static object Eval(object source, string expression)
        {
            object obj2;
            try
            {
                obj2 = DataBinder.Eval(source, expression);
            }
            catch (HttpException exception)
            {
                throw new FormatException(null, exception);
            }
            return obj2;
        }

        public static string FormatRegexPattern(this string regex)
        {
            bool flag = !regex.StartsWith("new RegExp");
            if (!regex.StartsWith("/", StringComparison.InvariantCulture) && flag)
            {
                regex = "/{0}".FormatWith(regex);
            }
            if (!regex.EndsWith("/", StringComparison.InvariantCulture) && flag)
            {
                regex = "{0}/".FormatWith(regex);
            }
            return regex;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(string.Format("The args parameter can not be null when calling {0}.FormatWith().", format));
            }
            return string.Format(format, args);
        }

        public static string FormatWith(this string format, object source)
        {
            return format.FormatWith(null, source);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            Verify.IsNotNull(format, "format");
            return string.Format(provider, format, args);
        }

        [Description("")]
        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            List<object> values = new List<object>();
            string str = Regex.Replace(format, @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+", delegate(Match m)
            {
                Group group = m.Groups["start"];
                Group group2 = m.Groups["property"];
                Group group3 = m.Groups["format"];
                Group group4 = m.Groups["end"];
                values.Add((group2.Value == "0") ? source : Eval(source, group2.Value));
                int count = group.Captures.Count;
                int num2 = group4.Captures.Count;
                if ((count <= num2) && ((count % 2) != 0))
                {
                    return string.Concat(new object[] { new string('{', count), values.Count - 1, group3.Value, new string('}', num2) });
                }
                return m.Value;
            }, RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return string.Format(provider, str, values.ToArray());
        }

        public static string If(this string text, string test, string valueIfTrue)
        {
            return text.If<string>(() => (text == test), valueIfTrue, text);
        }

        public static string IfNot(this string text, string test, string valueIfTrue)
        {
            return text.IfNot<string>(() => (text == test), valueIfTrue, text);
        }

        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsLowerCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return false;
            }
            return text.Substring(0, 1).ToLowerInvariant().Equals(text.Substring(0, 1));
        }

        public static bool IsNotEmpty(this string text)
        {
            return !text.IsEmpty();
        }

        public static string Join(this IEnumerable items)
        {
            return items.Join(",", "{0}");
        }

        public static string Join(this IEnumerable items, string separator)
        {
            return items.Join(separator, "{0}");
        }

        public static string Join(this IEnumerable items, string separator, string template)
        {
            StringBuilder builder = new StringBuilder();
            foreach (object obj2 in items)
            {
                if (obj2 != null)
                {
                    builder.Append(separator);
                    builder.Append(string.Format(template, obj2.ToString()));
                }
            }
            return builder.ToString().RightOf(separator);
        }

        public static string LeftOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = text.IndexOf(c);
            if (index == -1)
            {
                return text;
            }
            return text.Substring(0, index);
        }

        public static string LeftOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = text.IndexOf(value);
            if (index == -1)
            {
                return text;
            }
            return text.Substring(0, index);
        }

        public static string LeftOf(this string text, char c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int length = -1;
            while (n != 0)
            {
                length = text.IndexOf(c, length + 1);
                if (length == -1)
                {
                    return text;
                }
                n--;
            }
            return text.Substring(0, length);
        }

        public static string LeftOfRightmostOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int length = text.LastIndexOf(c);
            if (length == -1)
            {
                return text;
            }
            return text.Substring(0, length);
        }

        public static string LeftOfRightmostOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int length = text.LastIndexOf(value);
            if (length == -1)
            {
                return text;
            }
            return text.Substring(0, length);
        }

        public static string PadLeft(this string text, char c, int totalLength)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            if (totalLength < text.Length)
            {
                return text;
            }
            return (new string(c, totalLength - text.Length) + text);
        }

        public static string PadRight(this string text)
        {
            return text.PadRight('0', 2);
        }

        public static string PadRight(this string text, char c, int totalLength)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            if (totalLength < text.Length)
            {
                return text;
            }
            return (text + new string(c, totalLength - text.Length));
        }

        public static string Randomize(this string chars)
        {
            return chars.Randomize(chars.Length);
        }

        public static string Randomize(this string chars, int length)
        {
            char[] chArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                chArray[i] = chars[random.Next(chars.Length)];
            }
            return new string(chArray);
        }

        [Description("Replaces all occurrences of System.String in the oldValues String Array, with another specified System.String of newValue.")]
        public static string Replace(this string instance, string[] oldValues, string newValue)
        {
            if ((oldValues != null) && (oldValues.Length >= 1))
            {
                oldValues.Each<string>(delegate(string value)
                {
                    instance.Replace(value, newValue);
                });
            }
            return instance;
        }

        [Description("Replaces all occurrences of System.String in the oldValue String Array, with the return String value of the specified Function convert.")]
        public static string Replace(this string instance, string[] oldValues, Func<string, string> convert)
        {
            if ((oldValues != null) && (oldValues.Length >= 1))
            {
                oldValues.Each<string>(delegate(string value)
                {
                    instance = instance.Replace(value, convert(value));
                });
            }
            return instance;
        }

        public static string ReplaceLastInstanceOf(this string text, string oldValue, string newValue)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return string.Format("{0}{1}{2}", text.LeftOfRightmostOf(oldValue), newValue, text.RightOfRightmostOf(oldValue));
        }

        public static string RightOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = text.IndexOf(c);
            if (index == -1)
            {
                return "";
            }
            return text.Substring(index + 1);
        }

        public static string RightOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = text.IndexOf(value);
            if (index == -1)
            {
                return "";
            }
            return text.Substring(index + value.Length);
        }

        public static string RightOf(this string text, char c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = -1;
            while (n != 0)
            {
                index = text.IndexOf(c, index + 1);
                if (index == -1)
                {
                    return "";
                }
                n--;
            }
            return text.Substring(index + 1);
        }

        public static string RightOf(this string text, string c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int index = -1;
            while (n != 0)
            {
                index = text.IndexOf(c, (int)(index + 1));
                if (index == -1)
                {
                    return "";
                }
                n--;
            }
            return text.Substring(index + 1);
        }

        public static string RightOfRightmostOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int num = text.LastIndexOf(c);
            if (num == -1)
            {
                return text;
            }
            return text.Substring(num + 1);
        }

        public static string RightOfRightmostOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            int num = text.LastIndexOf(value);
            if (num == -1)
            {
                return text;
            }
            return text.Substring(num + value.Length);
        }

        [Description("Return a sub array of this string array.")]
        public static string[] Subarray(this string[] items, int start)
        {
            return items.Subarray(start, (items.Length - start));
        }

        [Description("Return a sub array of this string array.")]
        public static string[] Subarray(this string[] items, int start, int length)
        {
            if (start > items.Length)
            {
                throw new ArgumentException(string.Format("The start index [{0}] is greater than the length [{1}] of the array.", start, items.Length));
            }
            if ((start + length) > items.Length)
            {
                throw new ArgumentException(string.Format("The length [{0}] to return is greater than the length [{1}] of the array.", length, items.Length));
            }
            string[] strArray = new string[length];
            int index = 0;
            for (int i = start; i < (start + length); i++)
            {
                strArray[index] = items[i];
                index++;
            }
            return strArray;
        }

        public static bool Test(this string text, string pattern)
        {
            return Regex.IsMatch(text, pattern);
        }

        public static bool Test(this string text, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(text, pattern, options);
        }

        public static string ToCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return (text.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + text.Substring(1));
        }

        public static string ToCamelCase(this string[] values)
        {
            return values.ToCamelCase("");
        }

        public static string ToCamelCase(this string[] values, string separator)
        {
            string str = "";
            foreach (string str2 in values)
            {
                str = str + separator + str2.ToCamelCase();
            }
            return str;
        }

        public static string ToCharacterSeparatedFileName(this string name, char separator, string extension)
        {
            if (name.IsEmpty())
            {
                return name;
            }
            MatchCollection matchs = Regex.Matches(name, @"([A-Z]+)[a-z]*|\d{1,}[a-z]{0,}");
            string str = "";
            for (int i = 0; i < matchs.Count; i++)
            {
                if (i != 0)
                {
                    str = str + separator;
                }
                str = str + matchs[i].ToString().ToLowerInvariant();
            }
            string format = string.IsNullOrEmpty(extension) ? "{0}{1}" : "{0}.{1}";
            return string.Format(format, str, extension);
        }

        public static string ToLowerCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return (text.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + text.Substring(1));
        }

        public static string ToLowerCamelCase(this string[] values)
        {
            if ((values != null) && (values.Length != 0))
            {
                return values.ToLowerCamelCase();
            }
            return "";
        }

        public static string ToMD5Hash(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            MD5 md = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text.Trim());
            byte[] buffer2 = md.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer2.Length; i++)
            {
                builder.Append(buffer2[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string ToTitleCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return text.Split(new char[] { ' ' }).ToTitleCase();
        }

        public static string ToTitleCase(this string[] words)
        {
            return words.ToTitleCase(null);
        }

        public static string ToTitleCase(this string text, CultureInfo ci)
        {
            if (text.IsEmpty())
            {
                return text;
            }
            return text.Split(new char[] { ' ' }).ToTitleCase(ci);
        }

        public static string ToTitleCase(this string[] words, CultureInfo ci)
        {
            if ((words == null) || (words.Length == 0))
            {
                return "";
            }
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ((ci != null) ? char.ToUpper(words[i][0], ci) : char.ToUpper(words[i][0])) + words[i].Substring(1);
            }
            return string.Join(" ", words);
        }

        public static string Wrap(this string text, string wrapByText)
        {
            if (text == null)
            {
                text = "";
            }
            return wrapByText.ConcatWith(new object[] { text, wrapByText });
        }

        public static string Wrap(this string text, string wrapStart, string wrapEnd)
        {
            if (text == null)
            {
                text = "";
            }
            return wrapStart.ConcatWith(new object[] { text, wrapEnd });
        }
    }
}