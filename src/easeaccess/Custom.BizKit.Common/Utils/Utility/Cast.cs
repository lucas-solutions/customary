using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Custom.Core
{
    public partial class Cast
    {
        private class RegexList
        {
#if SILVERLIGHT
            public static readonly Regex AspNetAjaxJavaScriptDate = new Regex("/Date[(]{1}(?<Ticks>[0-9]*)[)]{1}/", RegexOptions.IgnoreCase);
#else
            public static readonly Regex AspNetAjaxJavaScriptDate = new Regex("/Date[(]{1}(?<Ticks>[0-9]*)[)]{1}/", RegexOptions.IgnoreCase | RegexOptions.Compiled);
#endif
        }

        private static NumberStyles _DefaultNumberStyle = NumberStyles.Integer;
        private static NumberStyles _DefaultDoubleNumberStyle = NumberStyles.Float | NumberStyles.AllowThousands;
        private static DateTimeStyles _DefaultDateTimeStyle = DateTimeStyles.AllowWhiteSpaces;
        /// <summary>
        /// 
        /// </summary>
        public static NumberStyles DefaultNumberStyle
        {
            get { return _DefaultNumberStyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static NumberStyles DefaultDoubleNumberStyle
        {
            get { return _DefaultDoubleNumberStyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static DateTimeStyles DefaultDateTimeStyle
        {
            get { return _DefaultDateTimeStyle; }
        }

        /// <summary>
        /// 指定したオブジェクトをSByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static SByte ToSByte(Object value, SByte defaultValue)
        {
            return ToSByte(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをSByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static SByte ToSByte(Object value, SByte defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToSByte(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 ToInt16(Object value, Int16 defaultValue)
        {
            return ToInt16(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int16 ToInt16(Object value, Int16 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToInt16(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int32 ToInt32(Object value, Int32 defaultValue)
        {
            return ToInt32(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int32 ToInt32(Object value, Int32 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToInt32(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 ToInt64(Object value, Int64 defaultValue)
        {
            return ToInt64(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int64 ToInt64(Object value, Int64 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToInt64(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Byte ToByte(Object value, Byte defaultValue)
        {
            return ToByte(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Byte ToByte(Object value, Byte defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToByte(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt16 ToUInt16(Object value, UInt16 defaultValue)
        {
            return ToUInt16(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt16 ToUInt16(Object value, UInt16 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToUInt16(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt32 ToUInt32(Object value, UInt32 defaultValue)
        {
            return ToUInt32(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt32 ToUInt32(Object value, UInt32 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToUInt32(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt64 ToUInt64(Object value, UInt64 defaultValue)
        {
            return ToUInt64(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt64 ToUInt64(Object value, UInt64 defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToUInt64(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをSingleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Single ToSingle(Object value, Single defaultValue)
        {
            return ToSingle(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをSingleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Single ToSingle(Object value, Single defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToSingle(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDoubleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Double ToDouble(Object value, Double defaultValue)
        {
            return ToDouble(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDoubleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Double ToDouble(Object value, Double defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToDouble(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDecimalに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(Object value, Decimal defaultValue)
        {
            return ToDecimal(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDecimalに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(Object value, Decimal defaultValue, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            return ToDecimal(value, numberStyle, formatProvider) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをBooleanに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Boolean ToBoolean(Object value, Boolean defaultValue)
        {
            return ToBoolean(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをTimeSpanに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(Object value, TimeSpan defaultValue)
        {
            return ToTimeSpan(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(Object value, DateTime defaultValue)
        {
            return ToDateTime(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(Object value, DateTime defaultValue, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            return ToDateTime(value, formatProvider, dateTimeStyle) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(Object value, DateTimeOffset defaultValue)
        {
            return ToDateTimeOffset(value) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(Object value, DateTimeOffset defaultValue, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            return ToDateTimeOffset(value, formatProvider, dateTimeStyle) ?? defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToEnum<T>(Object value) where T : struct
        {
            if (value == null)
            {
                return null;
            }

            T result;
            if (Enum.TryParse(value.ToString(), true, out result))
            {
                return result;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(Object value, T defaultValue) where T : struct
        {
            return ToEnum(value, defaultValue, true);
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(Object value, T defaultValue, Boolean ignoreCase) where T : struct
        {
            if (value == null)
            {
                return defaultValue;
            }

            T result;
            if (Enum.TryParse(value.ToString(), ignoreCase, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? IsDefinedAndParseToEnum<T>(Object value) where T : struct
        {
            return IsDefinedAndParseToEnum<T>(value, true);
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T? IsDefinedAndParseToEnum<T>(Object value, Boolean ignoreCase) where T : struct
        {
            String s = ToStringOrEmpty(value);
            if (typeof(T).IsEnum == false)
            {
                return null;
            }
            if (Enum.IsDefined(typeof(T), s))
            {
                return (T)Enum.Parse(typeof(T), s, ignoreCase);
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T IsDefinedAndParseToEnum<T>(Object value, T defaultValue) where T : struct
        {
            return IsDefinedAndParseToEnum(value, defaultValue, true);
        }
        /// <summary>
        /// 指定したオブジェクトを指定した型のEnumに変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T IsDefinedAndParseToEnum<T>(Object value, T defaultValue, Boolean ignoreCase) where T : struct
        {
            String s = ToStringOrEmpty(value);
            if (typeof(T).IsEnum == false)
            {
                return defaultValue;
            }
            if (Enum.IsDefined(typeof(T), s))
            {
                return (T)Enum.Parse(typeof(T), s, ignoreCase);
            }
            return defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをSByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SByte? ToSByte(Object value)
        {
            return ToSByte(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをSByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static SByte? ToSByte(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            SByte x;

            if (SByte.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16? ToInt16(Object value)
        {
            return ToInt16(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int16? ToInt16(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int16 x;

            if (Int16.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32? ToInt32(Object value)
        {
            return ToInt32(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int32? ToInt32(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int32 x;

            if (Int32.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int64? ToInt64(Object value)
        {
            return ToInt64(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Int64? ToInt64(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Int64 x;

            if (Int64.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Byte? ToByte(Object value)
        {
            return ToByte(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをByteに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Byte? ToByte(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Byte x;

            if (Byte.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UInt16? ToUInt16(Object value)
        {
            return ToUInt16(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをUInt16に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt16? ToUInt16(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt16 x;

            if (UInt16.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UInt32? ToUInt32(Object value)
        {
            return ToUInt32(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをUInt32に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt32? ToUInt32(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt32 x;

            if (UInt32.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをUInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UInt64? ToUInt64(Object value)
        {
            return ToUInt64(value, DefaultNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをUInt64に変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static UInt64? ToUInt64(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            UInt64 x;

            if (UInt64.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをSingleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Single? ToSingle(Object value)
        {
            return ToSingle(value, DefaultDoubleNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをSingleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Single? ToSingle(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Single x;

            if (value.GetType() == typeof(Single))
            { return (Single)value; }
            if (Single.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDoubleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double? ToDouble(Object value)
        {
            return ToDouble(value, DefaultDoubleNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをDoubleに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Double? ToDouble(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Double x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(Double))
            { return (Double)value; }
            if (Double.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDecimalに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Decimal? ToDecimal(Object value)
        {
            return ToDecimal(value, DefaultDoubleNumberStyle, null);
        }
        /// <summary>
        /// 指定したオブジェクトをDecimalに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberStyle"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static Decimal? ToDecimal(Object value, NumberStyles numberStyle, IFormatProvider formatProvider)
        {
            Decimal x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(Decimal))
            { return (Decimal)value; }
            if (Decimal.TryParse(ToStringOrEmpty(value), numberStyle, formatProvider, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをBooleanに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean? ToBoolean(Object value)
        {
            Boolean? rt = null;
            Boolean x;

            if (value == null)
            { return rt; }

            if (Boolean.TryParse(ToStringOrEmpty(value), out x))
            {
                rt = x;
            }
            return rt;
        }
        /// <summary>
        /// 文字列を取得します。nullの場合は空文字を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToString(Object value)
        {
            return ToStringOrEmpty(value);
        }
        /// <summary>
        /// 文字列を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToStringOrEmpty(Object value)
        {
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        /// <summary>
        /// 文字列もしくはnullを取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToStringOrNull(Object value)
        {
            return ToStringOrNull(value, true);
        }
        /// <summary>
        /// 文字列もしくはnullを取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isCastEmptyToNull"></param>
        /// <returns></returns>
        public static String ToStringOrNull(Object value, Boolean isCastEmptyToNull)
        {
            if (value == null)
            {
                return null;
            }
            if(isCastEmptyToNull && value.ToString() == String.Empty)
            {
                return null;
            }
            return value.ToString();
        }

        /// <summary>
        /// 指定したオブジェクトがnullもしくは空文字の場合にはnullを返し、それ以外の場合は文字列を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToStringOrNull(String value)
        {
            return value == "" ? null : value;
        }

        /// <summary>
        /// 指定したオブジェクトがnullの場合にDBNull.Valueに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Object ToDBValue(Object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        /// <summary>
        /// 指定したオブジェクトをTimeSpanに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan? ToTimeSpan(Object value)
        {
            TimeSpan x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(TimeSpan))
            { return (TimeSpan)value; }
            if (TimeSpan.TryParse(ToStringOrEmpty(value), out x))
            { return x; }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(Object value)
        {
            return ToDateTime(value, null, DateTimeStyles.AllowWhiteSpaces);
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(Object value, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            DateTime x;
            Regex rx = RegexList.AspNetAjaxJavaScriptDate;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTime))
            { return (DateTime)value; }
            if (DateTime.TryParse(ToStringOrEmpty(value), formatProvider, dateTimeStyle, out x))
            { return x; }
            // System.Web.Script.Serialization.JavaScriptSerializerで使用される/Date000000000形式の文字列からDateTimeを生成します。
            Match m = rx.Match(ToStringOrEmpty(value));
            if (String.IsNullOrEmpty(m.Value) == false)
            { return new DateTime(1970, 1, 1).AddMilliseconds(Double.Parse(m.Groups["Ticks"].Value)).ToLocalTime(); }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeExact(Object value, String format, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            DateTime x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTime))
            { return (DateTime)value; }
            if (DateTime.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeExact(Object value, String[] format, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            DateTime x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTime))
            { return (DateTime)value; }
            if (DateTime.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeExact(Object value, String format, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle
            , DateTime defaultValue)
        {
            DateTime x;

            if (value == null)
            { return defaultValue; }
            if (value.GetType() == typeof(DateTime))
            { return (DateTime)value; }
            if (DateTime.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeExact(Object value, String[] format, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle
            , DateTime defaultValue)
        {
            DateTime x;

            if (value == null)
            { return defaultValue; }
            if (value.GetType() == typeof(DateTime))
            { return (DateTime)value; }
            if (DateTime.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffset(Object value)
        {
            return ToDateTimeOffset(value, null, DateTimeStyles.AllowWhiteSpaces);
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffset(Object value, IFormatProvider formatProvider, DateTimeStyles dateTimeStyle)
        {
            DateTimeOffset x;
            Regex rx = RegexList.AspNetAjaxJavaScriptDate;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTimeOffset))
            { return (DateTimeOffset)value; }
            if (DateTimeOffset.TryParse(ToStringOrEmpty(value), formatProvider, dateTimeStyle, out x))
            { return x; }
            // System.Web.Script.Serialization.JavaScriptSerializerで使用される/Date000000000形式の文字列からDateTimeOffsetを生成します。
            Match m = rx.Match(ToStringOrEmpty(value));
            if (String.IsNullOrEmpty(m.Value) == false)
            { return new DateTimeOffset(new DateTime(1970, 1, 1).AddMilliseconds(Double.Parse(m.Groups["Ticks"].Value)).ToLocalTime()); }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffsetExact(Object value, String format, IFormatProvider formatProvider
            , DateTimeStyles dateTimeStyle, DateTimeOffset defaultValue)
        {
            DateTimeOffset x;

            if (value == null)
            { return defaultValue; }
            if (value.GetType() == typeof(DateTimeOffset))
            { return (DateTimeOffset)value; }
            if (DateTimeOffset.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffsetExact(Object value, String[] format, IFormatProvider formatProvider
            , DateTimeStyles dateTimeStyle, DateTimeOffset defaultValue)
        {
            DateTimeOffset x;

            if (value == null)
            { return defaultValue; }
            if (value.GetType() == typeof(DateTimeOffset))
            { return (DateTimeOffset)value; }
            if (DateTimeOffset.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return defaultValue;
        }

        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffsetExact(Object value, String format, IFormatProvider formatProvider
            , DateTimeStyles dateTimeStyle)
        {
            DateTimeOffset x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTimeOffset))
            { return (DateTimeOffset)value; }
            if (DateTimeOffset.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// 指定したオブジェクトをDateTimeOffsetに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dateTimeStyle"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffsetExact(Object value, String[] format, IFormatProvider formatProvider
            , DateTimeStyles dateTimeStyle)
        {
            DateTimeOffset x;

            if (value == null)
            { return null; }
            if (value.GetType() == typeof(DateTimeOffset))
            { return (DateTimeOffset)value; }
            if (DateTimeOffset.TryParseExact(ToStringOrEmpty(value), format, formatProvider, dateTimeStyle, out x))
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 指定したオブジェクトをGuidに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid ToGuid(Object value, Guid defaultValue)
        {
            Guid? guid = ToGuid(value);
            return guid.HasValue ? guid.Value : defaultValue;
        }
        /// <summary>
        /// 指定したオブジェクトをGuidに変換します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid? ToGuid(Object value)
        {
            if (value == null)
            {
                return null;
            }

            Guid guid;
            if (Guid.TryParse(value.ToString(), out guid))
            {
                return guid;
            }
            return null;
        }
        /// <summary>
        /// コレクションから指定したキーの要素を取得します。キーが存在しない場合、nullを返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            return GetValue(dictionary, key, null);
        }
        /// <summary>
        /// コレクションから指定したキーの要素を取得します。キーが存在しない場合、defaultValueで指定したオブジェクトを返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TValue GetValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) where TValue : class
        {
            TValue o;
            if (dictionary.TryGetValue(key, out o))
            {
                return o;
            }
            return defaultValue;
        }
        /// <summary>
        /// コレクションから指定したキーの要素を取得します。キーが存在しない場合、nullを返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue? GetValue<TKey, TValue>(IDictionary<TKey, TValue?> dictionary, TKey key) where TValue : struct
        {
            return GetValue(dictionary, key, null);
        }
        /// <summary>
        /// コレクションから指定したキーの要素を取得します。キーが存在しない場合、defaultValueで指定したオブジェクトを返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TValue? GetValue<TKey, TValue>(IDictionary<TKey, TValue?> dictionary, TKey key, TValue? defaultValue) where TValue : struct
        {
            TValue? o;
            if (dictionary.TryGetValue(key, out o))
            {
                return dictionary[key];
            }
            return defaultValue;
        }
#if !SILVERLIGHT
        /// <summary>
        /// バイト配列を解析し適切なエンコードを行うEncodingオブジェクトを取得します。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Encoding GetEncoding(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }
#endif
    }
}