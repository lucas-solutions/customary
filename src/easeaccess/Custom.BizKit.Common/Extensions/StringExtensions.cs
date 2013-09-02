using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Newtonsoft.Json;
    using System.Globalization;
    using Dictionary = Dictionary<string, object>;

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

        public static bool TryGetValue(this String stream, out Dictionary value)
        {
            value = DeserializeJsonObject(stream);

            return value != null;
        }

        public static bool TryGetValue(this String stream, string contentType, out Dictionary value)
        {
            value = DeserializeJsonObject(stream);

            return false;
        }

        public static bool TryGetValue<T>(this String stream, out T value)
            where T : new()
        {
            value = DeserializeJsonObject<T>(stream);
            return value != null;
        }

        public static bool TryGetValue<T>(this String stream, string contentType, out T value)
            where T : new()
        {
            value = DeserializeJsonObject<T>(stream);
            return value != null;
        }

        private static TypeCode DetectContentType(String stream, out string contentType)
        {
            contentType = null;

            return TypeCode.Object;
        }

        private static Dictionary DeserializeJsonObject(string json)
        {
            var obj = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            System.Diagnostics.Debug.Assert(typeof(Dictionary).IsInstanceOfType(obj));

            return (Dictionary)obj;

        }

        private static T DeserializeJsonObject<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            return obj;
        }

        private static readonly Random random = new Random();

        public static string Base64Decode(this string text)
        {
            Decoder decoder = new UTF8Encoding().GetDecoder();
            byte[] buffer = Convert.FromBase64String(text);
            char[] chArray = new char[decoder.GetCharCount(buffer, 0, buffer.Length)];
            decoder.GetChars(buffer, 0, buffer.Length, chArray, 0);
            return new string(chArray);
        }

        public static string Base64Encode(this string text)
        {
            byte[] buffer = new byte[text.Length];
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }
        
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
                int num = character.Length;
                return text.Substring(num, text.Length - (num + 1));
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
            int num2 = text.Length;
            StringBuilder builder = new StringBuilder(num2 + 4);
            for (int i = 0; i < num2; i++)
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
                            string str2 = new string(ch, 1);
                            string str = "000" + int.Parse(str2, (NumberStyles)NumberStyles.HexNumber);
                            builder.Append(@"\u" + str.Substring((int)(str.Length - 4)));
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

        public static object FromJson(this string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(value);
        }

        public static T FromJson<T>(this string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
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
            int index = -1;
            while (n != 0)
            {
                index = text.IndexOf(c, index + 1);
                if (index == -1)
                {
                    return text;
                }
                n--;
            }
            return text.Substring(0, index);
        }

        public static string LeftOfRightmostOf(this string text, char c)
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
            return text.Substring(0, num);
        }

        public static string LeftOfRightmostOf(this string text, string value)
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
            return text.Substring(0, num);
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

        /// <summary>
        /// Replaces all occurrences of System.String in the oldValues String Array, with another specified System.String of newValue.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="oldValues"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
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
            return text.Substring((int)(index + 1));
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
            return text.Substring((int)(index + value.Length));
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
            return text.Substring((int)(index + 1));
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
                index = text.IndexOf(c, index + 1);
                if (index == -1)
                {
                    return "";
                }
                n--;
            }
            return text.Substring((int)(index + 1));
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
            return text.Substring((int)(num + 1));
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
            return text.Substring((int)(num + value.Length));
        }

        /// <summary>
        /// Return a sub array of this string array.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static string[] Subarray(this string[] items, int start)
        {
            return items.Subarray(start, (items.Length - start));
        }

        /// <summary>
        /// Return a sub array of this string array.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
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

        public static string ToJson(this object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
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
