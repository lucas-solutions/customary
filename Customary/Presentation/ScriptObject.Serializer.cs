using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Custom.Presentation
{
    partial class ScriptObject
    {
        public abstract class Serializer<TModel, TSerializer> : Scriptable.Serializer, IHtmlString
            where TModel : ScriptObject
            where TSerializer : Serializer<TModel, TSerializer>
        {
            public static implicit operator ScriptView(Serializer<TModel, TSerializer> serializer)
            {
                return serializer._view;
            }

            public static implicit operator TModel(Serializer<TModel, TSerializer> serializer)
            {
                return serializer._model;
            }

            private TModel _model;
            private ScriptView _view;
            private string _master;
            private Dictionary<string, Delegate> _propertyRender;

            public Serializer(TModel model)
            {
                _model = model;
                _propertyRender = new Dictionary<string, Delegate>();
            }

            public virtual TModel ToModel()
            {
                return _model;
            }

            public TSerializer Property<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, Func<string[]> render)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _propertyRender[propertyInfo.Name] = render;
                }
                return (TSerializer)this;
            }

            public TSerializer Property<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, Func<TProperty, string[]> render)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _propertyRender[propertyInfo.Name] = render;
                }
                return (TSerializer)this;
            }

            public TSerializer Ignore<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _propertyRender[propertyInfo.Name] = null;
                }
                return (TSerializer)this;
            }

            /// <summary>
            /// Render the value of property from the text in the file as is.
            /// </summary>
            /// <typeparam name="TProperty"></typeparam>
            /// <param name="propertyLambda"></param>
            /// <param name="path"></param>
            /// <returns></returns>
            public TSerializer File<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, string path)
            {
                return (TSerializer)this;
            }

            /// <summary>
            /// Render the value of property from the text in the view as is.
            /// </summary>
            /// <typeparam name="TProperty"></typeparam>
            /// <param name="propertyLambda"></param>
            /// <param name="path"></param>
            /// <returns></returns>
            public TSerializer View<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, string path)
            {
                return (TSerializer)this;
            }

            /// <summary>
            /// Set the master view path
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public TSerializer Master(string path)
            {
                _master = path;
                return (TSerializer)this;
            }

            public new TSerializer Override(Func<string[]> render)
            {
                base.Override(render);
                return (TSerializer)this;
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
                        memberWriter.Write(name + ": ");
                        if (TryRenderValue(value, memberWriter))
                        {
                            if (isEmpty)
                                isEmpty = false;
                            else
                                writer.WriteLine(',');

                            writer.Merge(memberWriter);

                            memberWriter.Reset();
                        }
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
                        if (TryRenderValue(pair.Value, pairWriter))
                        {
                            if (isEmpty)
                                isEmpty = false;
                            else
                                writer.WriteLine(',');

                            writer.Merge(pairWriter);

                            pairWriter.Reset();
                        }
                    }
                }

                if (!isEmpty)
                    writer.WriteLine();

                writer.Write('}');

                return true;
            }

            protected virtual bool TryRenderScriptable(IScriptable value, ScriptWriter writer)
            {
                if (value == null)
                    return false;

                writer.Write(value.ToSerializer().Render());

                return true;
            }

            protected virtual bool TryRenderProperty(string name, IScriptable value, ScriptWriter writer)
            {
                if (value == null)
                    return false;

                var script = value.ToSerializer().Render();

                if (script == null || script.Length.Equals(0))
                    return false;

                writer.Write(name);
                writer.Write(':');
                writer.Write(' ');
                writer.Write(script);

                return true;
            }

            protected virtual bool TryRenderValue(object value, ScriptWriter writer)
            {
                if (value == null)
                    return false;

                var valueType = value.GetType();
                var valueTypeCode = Type.GetTypeCode(valueType);

                switch (valueTypeCode)
                {
                    case TypeCode.DBNull:
                    case TypeCode.Empty:
                        break;

                    case TypeCode.Boolean:
                        break;

                    case TypeCode.Char:
                        writer.Value((char)value);
                        break;

                    case TypeCode.Decimal:
                        writer.Value((decimal)value);
                        break;

                    case TypeCode.Double:
                    case TypeCode.Single:
                        break;

                    case TypeCode.Byte:
                        writer.Value((byte)value);
                        break;

                    case TypeCode.Int16:
                        writer.Value((short)value);
                        break;

                    case TypeCode.Int32:
                        writer.Value((int)value);
                        break;

                    case TypeCode.Int64:
                        writer.Value((long)value);
                        break;

                    case TypeCode.SByte:
                        writer.Value((sbyte)value);
                        break;

                    case TypeCode.UInt16:
                        writer.Value((ushort)value);
                        break;

                    case TypeCode.UInt32:
                        writer.Value((uint)value);
                        break;

                    case TypeCode.UInt64:
                        writer.Value((ulong)value);
                        break;

                    case TypeCode.DateTime:
                        writer.Value((DateTime)value);
                        break;

                    case TypeCode.String:
                        writer.Value((string)value);
                        break;

                    case TypeCode.Object:
                        if (TryRenderScriptable(value as IScriptable, writer))
                            return true;

                        if (TryRenderDictionary(value as IDictionary<string, object>, writer))
                            return true;

                        if (TryRenderDictionary(value as IDictionary<string, string>, writer))
                            return true;

                        if (TryRenderEnumerable(value as IEnumerable, writer))
                            return true;

                        if (TryRenderDynamic(value as DynamicObject, writer))
                            return true;

                        if (TryRenderDynamic(value as IDynamicMetaObjectProvider, writer))
                            return true;

                        return TryRenderObject(value, writer);
                }

                return true;
            }

            protected virtual bool TryRenderEnumerable(IEnumerable value, ScriptWriter writer)
            {
                if (value == null)
                    return false;

                writer.Write('[');

                var itemWriter = new ScriptWriter();

                var isEmpty = true;
                var enumerator = value.GetEnumerator();
                if (enumerator != null && enumerator.MoveNext())
                {
                    if (TryRenderValue(enumerator.Current, itemWriter))
                    {
                        if (isEmpty)
                            isEmpty = false;
                        else
                            writer.WriteLine(',');

                        writer.Merge(itemWriter);

                        itemWriter.Reset();
                    }
                }

                if (!isEmpty)
                    writer.WriteLine();

                writer.Write(']');

                return true;
            }

            protected virtual bool TryRenderObject(object value, ScriptWriter writer)
            {
                if (value == null)
                    return false;

                writer.Write('{');

                var propWriter = new ScriptWriter();
                var arr = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var isFirst = true;
                foreach (var propInfo in arr)
                {
                    Delegate render;
                    if (!_propertyRender.TryGetValue(propInfo.Name, out render))
                    {
                        propWriter.Write(propInfo.Name + ": ");

                        if (TryRenderValue(propInfo.GetValue(value), propWriter))
                        {
                            if (isFirst)
                                isFirst = false;
                            else
                                writer.WriteLine(',');

                            writer.Merge(propWriter);
                            propWriter.Reset();
                        }
                    }
                    else if (render != null)
                    {
                        string[] lines;
                        if (render.Method.GetParameters().Length.Equals(0))
                        {
                            var fn = (Func<string[]>)render;
                            lines = fn();
                        }
                        else
                        {
                            var propValue = propInfo.GetValue(value);
                            var target = render.Target;
                            var method = render.Method;
                            var args = new object[] { propValue };
                            lines = (string[])method.Invoke(target, args);
                        }

                        if (lines != null)
                        {
                            if (isFirst)
                                isFirst = false;
                            else
                                writer.WriteLine(',');

                            propWriter.Write(propInfo.Name + ": ");
                            writer.Merge(lines);
                        }
                    }
                }

                writer.WriteLine();
                writer.Write('}');

                return true;
            }

            public override void Serialize(TextWriter writer)
            {
                var sw = new ScriptWriter();
                if (TryRenderObject(_model, sw))
                    sw.WriteTo(writer);
            }

            string IHtmlString.ToHtmlString()
            {
                return ToString();
            }

            #region - reflection utils

            private PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda)
            {
                Type type = typeof(TModel);

                MemberExpression member = propertyLambda.Body as MemberExpression;
                if (member == null)
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        propertyLambda.ToString()));

                PropertyInfo propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                    throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda.ToString()));

                if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
                    throw new ArgumentException(string.Format("Expresion '{0}' refers to a property that is not from type {1}.", propertyLambda.ToString(), type));

                return propInfo;
            }

            #endregion - reflection utils

            protected override bool TryRender(out string[] lines)
            {
                if (base.TryRender(out lines))
                    return true;

                var writer = new ScriptWriter();
                if (TryRenderObject(_model, writer))
                {
                    lines = writer.Lines;
                    return true;
                }
                return false;
            }
        }
    }
}