using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Custom.Presentation
{
    public abstract class ScriptSerializer : IScriptSerializer
    {
        public static implicit operator MvcHtmlString(ScriptSerializer Serializer)
        {
            return Serializer != null ? new MvcHtmlString(Serializer.ToString()) : null;
        }

        private IView _view;
        private static ViewEngineCollection _viewEngineCollection;

        public IView View
        {
            get
            {
                Func<IView> findView = () =>
                    {
                        return null;
                    };

                return _view ?? (_view = findView());
            }
        }

        public T Cast<T>()
            where T : class, IScriptSerializer
        {
            return (this as T);
        }

        protected void Return(TextWriter writer, params Action<TextWriter>[] content)
        {
            writer.Write("return {");
            foreach (var action in content)
            {
                writer.WriteLine();
                action(writer);
            }
            writer.Write("};");
            writer.WriteLine();
        }

        public abstract void Serialize(ScriptWriter writer);
    }

    public abstract class ScriptSerializer<TModel, TSerializer> : ScriptSerializer, IScriptSerializer<TModel>, IHtmlString
        where TModel : Scriptable
        where TSerializer : ScriptSerializer<TModel, TSerializer>
    {
        private TModel _model;
        private ViewContext _viewContext;
        private string _master;
        private Dictionary<string, RenderInfo> _propertyRender;

        public static implicit operator TModel(ScriptSerializer<TModel, TSerializer> Serializer)
        {
            return Serializer._model;
        }

        public ScriptSerializer(TModel model)
        {
            _model = model;
        }

        protected virtual UrlHelper UrlHelper
        {
            get
            {
                ViewContext viewContext = ViewContext;
                return new UrlHelper((viewContext != null) ? viewContext.RequestContext : new RequestContext(), RouteTable.Routes);
            }
        }

        protected virtual ViewContext ViewContext
        {
            get { return _viewContext; }
        }

        public virtual TModel ToModel()
        {
            return _model;
        }

        public TSerializer Custom(Action<TModel, TextWriter> callback)
        {
            return (TSerializer)this;
        }

        public TSerializer Custom<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, Action<TProperty, TextWriter> callback)
        {
            var propertyInfo = GetPropertyInfo(propertyLambda);
            if (propertyInfo != null)
            {
                _propertyRender[propertyInfo.Name] = new RenderInfo { Property = propertyInfo, Callback = callback };
            }
            return (TSerializer)this;
        }

        public TSerializer Ignore<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda)
        {
            var propertyInfo = GetPropertyInfo(propertyLambda);
            if (propertyInfo != null)
            {
                _propertyRender[propertyInfo.Name] = new RenderInfo { Property = propertyInfo };
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

            value.Script(writer);

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
                RenderInfo renderInfo;
                if (!_propertyRender.TryGetValue(propInfo.Name, out renderInfo))
                {
                    propWriter.Write(propInfo.Name + ": ");

                    if (TryRenderValue(propInfo.GetValue(value), propWriter))
                    {
                        if (isFirst)
                            isFirst = false;
                        else
                            writer.WriteLine(',');

                        writer.Merge(propWriter);
                    }
                }
                else if (renderInfo.Callback != null)
                {
                    var propValue = propInfo.GetValue(value);
                    if (propValue != null)
                    {
                        propWriter.Write(propInfo.Name + ": ");

                        var target = renderInfo.Callback.Target;
                        var method = renderInfo.Callback.Method;
                        var args = new object[] { propValue, propWriter };

                        var succeeded = (bool)method.Invoke(target, args);

                        if (succeeded)
                        {
                            if (isFirst)
                                isFirst = false;
                            else
                                writer.WriteLine(',');

                            writer.Merge(propWriter);
                        }
                    }
                }
                propWriter.Reset();
            }

            writer.WriteLine();
            writer.Write('}');

            return true;
        }

        protected virtual void FileRender(TModel model, TextWriter writer)
        {
        }

        public ActionResult ToResult()
        {
            return null;
        }

        public virtual void Serialize(ViewContext viewContext)
        {
            _viewContext = viewContext;
            var writer = new ScriptWriter();
            Serialize(_model, writer);
            writer.WriteTo(viewContext.Writer);
        }

        public virtual void Serialize(TModel model, ViewContext viewContext)
        {
            _model = model;
            _viewContext = viewContext;
            var writer = new ScriptWriter();
            Serialize(model, writer);
            writer.WriteTo(viewContext.Writer);
        }

        public override void Serialize(ScriptWriter writer)
        {
            _viewContext = null;
            Serialize(_model, writer);
        }

        protected abstract void Serialize(TModel model, ScriptWriter writer);



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

        public override string ToString()
        {
            var writer = new ScriptWriter();
            Serialize(writer);
            return writer.ToString();
        }

        struct RenderInfo
        {
            public PropertyInfo Property;

            public string Path;

            /// <summary>
            /// Use null to ignore
            /// </summary>
            public Delegate Callback;
        }
    }
}