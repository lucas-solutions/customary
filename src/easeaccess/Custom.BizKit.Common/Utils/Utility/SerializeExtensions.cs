using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Custom.Extensions
{
    using Custom.Core;

    ///<summary>
    /// 
    ///</summary>
    public static class SerializeExtensions
    {
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToJson(this Object value)
        {
            return ToJson(value, null);
        }
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="converterList"></param>
        /// <returns></returns>
        public static String ToJson(this Object value, params JsonConvert[] converterList)
        {
            return ToJson(value, converterList as IEnumerable<JavaScriptConverter>);
        }
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="converterList"></param>
        /// <returns></returns>
        public static String ToJson(this Object value, IEnumerable<JavaScriptConverter> converterList)
        {
            return Cast.ToJson(value, converterList);
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(this String json)
        {
            return FromJson<T>(json, null);
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="converterList"></param>
        /// <returns></returns>
        public static T FromJson<T>(this String json, params JavaScriptConverter[] converterList)
        {
            return FromJson<T>(json, converterList as IEnumerable<JavaScriptConverter>);
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="converterList"></param>
        /// <returns></returns>
        public static T FromJson<T>(this String json, IEnumerable<JavaScriptConverter> converterList)
        {
            return Cast.FromJson<T>(json, converterList);
        }
        /// <summary>
        /// 指定したオブジェクトからXML形式の文字列を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToXml(this Object value)
        {
            return Cast.ToXml(value);
        }
        /// <summary>
        /// XML形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlText"></param>
        /// <returns></returns>
        public static T FromXml<T>(this String xmlText)
        {
            return Cast.FromXml<T>(xmlText);
        }
    }
}
