﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Custom.Presentation
{
    public abstract class Scriptable : IScriptable
    {
        public const int INLINE_LENGH = 40;
        public const string INDENT = "    ";

        private bool _camelCase = true;

        public bool CamelCase
        {
            get { return _camelCase; }
            set { _camelCase = value; }
        }

        public abstract void Render(List<string> lines);

        public virtual void Write(TextWriter writer)
        {
            var lines = new List<string>();
            Render(lines);
            writer.WriteAllLines(lines);
        }

        protected virtual bool TryRenderDynamic(IDynamicMetaObjectProvider dyn, ScriptWriter writer)
        {
            if (dyn == null)
                return false;

            var isEmpty = true;

            writer.Write('{');

            if (!isEmpty)
                writer.WriteLine();

            writer.Write('}');

            return true;
        }

        protected virtual bool TryRenderDynamic(DynamicObject dyn, ScriptWriter writer)
        {
            if (dyn == null)
                return false;

            var isEmpty = true;
            var memberWriter = new ScriptWriter();

            writer.Write('{');

            foreach (var name in dyn.GetDynamicMemberNames())
            {
                object value = null;

                if (value != null)
                {
                    /*memberWriter.Write(name + ": ");
                    if (TryRenderValue(value, memberWriter))
                    {
                        if (isEmpty)
                            isEmpty = false;
                        else
                            writer.WriteLine(',');

                        writer.Merge(memberWriter);

                        memberWriter.Reset();
                    }*/
                }
            }

            if (!isEmpty)
                writer.WriteLine();

            writer.Write('}');

            return true;
        }

        protected virtual bool TryRenderDictionary<TValue>(IDictionary<string, TValue> dic, ScriptWriter writer)
        {
            if (dic == null)
                return false;

            writer.Write('{');

            var isEmpty = true;
            var pairWriter = new ScriptWriter();

            foreach (var pair in dic)
            {
                if (pair.Value != null)
                {
                    pairWriter.Write(pair.Key + ": ");
                    /*if (TryRenderValue(pair.Value, pairWriter))
                    {
                        if (isEmpty)
                            isEmpty = false;
                        else
                            writer.WriteLine(',');

                        writer.Merge(pairWriter);

                        pairWriter.Reset();
                    }*/
                }
            }

            if (!isEmpty)
                writer.WriteLine();

            writer.Write('}');

            return true;
        }

        protected virtual bool RenderScriptable(IScriptable value, List<string> lines)
        {
            if (value == null)
                return false;

            value.Render(lines);

            return true;
        }

        protected virtual bool RenderValue(object value, List<string> output)
        {
            if (value == null)
                return false;

            var valueType = value.GetType();

            if (valueType.IsEnum)
            {
                if (valueType.IsEnumDefined(value))
                {
                    var name = Enum.GetName(valueType, value);

                    if (CamelCase)
                        name = name.CamelCase();

                    output.Add('\'' + name + '\'');

                    return true;
                }
            }

            var valueTypeCode = Type.GetTypeCode(valueType);

            switch (valueTypeCode)
            {
                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return false;

                case TypeCode.Boolean:
                    output.Add((bool)value ? "true" : "false");
                    return true;

                case TypeCode.Char:
                    output.Add("'" + (char)value + "'");
                    return true;

                case TypeCode.Decimal:
                    output.Add(((decimal)value).ToString());
                    return true;

                case TypeCode.Double:
                    output.Add(((double)value).ToString());
                    return true;

                case TypeCode.Single:
                    output.Add(((float)value).ToString());
                    return true;

                case TypeCode.Byte:
                    output.Add(((byte)value).ToString());
                    return true;

                case TypeCode.Int16:
                    output.Add(((short)value).ToString());
                    return true;

                case TypeCode.Int32:
                    output.Add(((int)value).ToString());
                    return true;

                case TypeCode.Int64:
                    output.Add(((long)value).ToString());
                    return true;

                case TypeCode.SByte:
                    output.Add(((sbyte)value).ToString());
                    return true;

                case TypeCode.UInt16:
                    output.Add(((ushort)value).ToString());
                    return true;

                case TypeCode.UInt32:
                    output.Add(((uint)value).ToString());
                    return true;

                case TypeCode.UInt64:
                    output.Add(((ulong)value).ToString());
                    return true;


                case TypeCode.DateTime:
                    output.Add(((DateTime)value).ToString());
                    return true;

                case TypeCode.String:
                    output.Add("\"" + ((string)value).Replace("\"", "\\\"") + "\"");
                    return true;

                case TypeCode.Object:

                    if (RenderScriptable(value as IScriptable, output))
                        return true;

                    /*if (TryRenderDictionary(value as IDictionary<string, object>, writer))
                        return true;

                    if (TryRenderDictionary(value as IDictionary<string, string>, writer))
                        return true;
                    */

                    if (RenderEnumerable(value as IEnumerable, output))
                        return true;

                    /*if (TryRenderDynamic(value as DynamicObject, writer))
                        return true;

                    if (TryRenderDynamic(value as IDynamicMetaObjectProvider, writer))
                        return true;*/

                    if (RenderObject(value, null, output))
                        return true;

                    return false;

                default:
                    return false;
            }
        }

        protected virtual bool RenderEnumerable(IEnumerable value, List<string> output)
        {
            if (value == null)
                return false;

            var content = new List<List<string>>();
            bool inline = true;
            int length = 0;

            var enumerator = value.GetEnumerator();
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    var lines = new List<string>();

                    if (RenderValue(enumerator.Current, lines))
                    {
                        if (lines.Count > 1)
                            inline = false;
                        else
                            length += lines[0].Length;

                        content.Add(lines);
                    }
                }

                if (inline && length < INLINE_LENGH)
                    output.Append(FormatInline(content));
                else
                    Format(content, output);
            }

            return true;
        }

        private object DefaultValue(PropertyInfo prop)
        {
            var attribute = prop.GetCustomAttribute<DefaultValueAttribute>(true);
            return (attribute != null) ? attribute.Value : null;
        }

        protected virtual bool RenderObject(object value, Dictionary<string, Delegate> propertyRender, List<string> output)
        {
            if (value == null)
            {
                return false;
            }

            var content = new Dictionary<string, List<string>>();
            bool inline = true;
            int length = 0;

            var propWriter = new ScriptWriter();
            var arr = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propInfo in arr)
            {
                var propValue = propInfo.GetValue(value);

                if (propValue == null || object.Equals(propValue, DefaultValue(propInfo)))
                    continue;

                Delegate render = null;
                var customRender = propertyRender != null && propertyRender.TryGetValue(propInfo.Name, out render);
                
                var lines = new List<string>();

                if (!customRender)
                    RenderValue(propInfo.GetValue(value), lines);
                else if (render != null)
                {
                    if (render.Method.GetParameters().Length.Equals(1))
                    {
                        var fn = (Action<List<string>>)render;
                        fn(lines);
                    }
                    else
                    {
                        var target = render.Target;
                        var method = render.Method;
                        var args = new object[] { lines, propValue };
                        method.Invoke(target, args);
                    }
                }

                if (lines != null && lines.Count > 0)
                {
                    if (lines.Count > 1)
                        inline = false;
                    else
                        length += lines[0].Length;

                    var name = propInfo.Name;

                    if (CamelCase)
                        name = name.CamelCase();

                    content.Add(name, lines);
                }
            }

            if (inline && length < INLINE_LENGH)
                output.Append(FormatInline(content));
            else
                Format(content, output);

            return true;
        }

        private void Format(List<List<string>> input, List<string> output)
        {
            output.Append('[');
            foreach (var lines in input)
            {
                output.AddRange(lines.Select(x => INDENT + x.TrimEnd()));
                output.Append(',');
            }
            output.TrimEnd(',');
            output.Add("]");
        }

        private string FormatInline(IEnumerable<List<string>> content)
        {
            return string.Concat("[ ", string.Join(", ", content.Select(x => string.Join(" ", x.Select(y => y.Trim())))), " ]");
        }

        private void Format(Dictionary<string, List<string>> content, List<string> output)
        {
            output.Append('{');
            foreach (var entry in content)
            {
                output.Add(INDENT + entry.Key + ": " + entry.Value.First().TrimEnd());
                output.AddRange(entry.Value.Skip(1).Select(x => INDENT + x.TrimEnd()));
                output.Append(',');
            }
            output.TrimEnd(',');
            output.Add("}");
        }

        private string FormatInline(Dictionary<string, List<string>> content)
        {
            return string.Concat("{ " + string.Join(", ", content.Select(x => x.Key + ": " + string.Join(" ", x.Value.Select(y => y.Trim())))) + " }");
        }
    }
}