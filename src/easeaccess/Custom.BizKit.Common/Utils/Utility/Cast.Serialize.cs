using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Custom.Core
{
    using Newtonsoft.Json;

    public partial class Cast
    {
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="inObject"></param>
        /// <returns></returns>
        public static String ToJson(Object inObject)
        {
            return ToJson(inObject, null);
        }
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="inObject"></param>
        /// <param name="inConverterList"></param>
        /// <returns></returns>
        public static String ToJson(Object inObject, params JavaScriptConverter[] inConverterList)
        {
            return ToJson(inObject, inConverterList as IEnumerable<JavaScriptConverter>);
        }
        /// <summary>
        /// 指定したオブジェクトからJSON形式の文字列を取得します。
        /// </summary>
        /// <param name="inObject"></param>
        /// <param name="inConverterList"></param>
        /// <returns></returns>
        public static String ToJson(Object inObject, IEnumerable<JavaScriptConverter> inConverterList)
        {
            if (inObject == null)
            { return ""; }

            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();

            if (inConverterList != null)
            {
                js.RegisterConverters(inConverterList);
            }
            js.Serialize(inObject, sb);
            return sb.ToString();
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(String inJson)
        {
            return FromJson<T>(inJson, null);
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inJson"></param>
        /// <param name="inConverterList"></param>
        /// <returns></returns>
        public static T FromJson<T>(String inJson, params JavaScriptConverter[] inConverterList)
        {
            return FromJson<T>(inJson, inConverterList as IEnumerable<JavaScriptConverter>);
        }
        /// <summary>
        /// JSON形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inJson"></param>
        /// <param name="inConverterList"></param>
        /// <returns></returns>
        public static T FromJson<T>(String inJson, IEnumerable<JavaScriptConverter> inConverterList)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (inConverterList != null)
            {
                js.RegisterConverters(inConverterList);
            }
            return js.Deserialize<T>(inJson);
        }
        /// <summary>
        /// 指定したオブジェクトからXML形式の文字列を取得します。
        /// </summary>
        /// <param name="inObject"></param>
        /// <returns></returns>
        public static String ToXml(Object inObject)
        {
            XmlSerializer sl = new XmlSerializer(inObject.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            sl.Serialize(sw, inObject);
            return sb.ToString();
        }
        /// <summary>
        /// XML形式の文字列からオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inXmlText"></param>
        /// <returns></returns>
        public static T FromXml<T>(String inXmlText)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(inXmlText));
        }
    }
}
