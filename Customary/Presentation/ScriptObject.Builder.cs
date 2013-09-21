using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace Custom.Presentation
{
    partial class ScriptObject
    {
        public abstract class Builder<TModel, TBuilder>
            where TModel : ScriptObject
            where TBuilder : Builder<TModel, TBuilder>
        {
            private readonly TModel _model;
            private string _master;
            

            public static implicit operator TModel(Builder<TModel, TBuilder> builder)
            {
                return builder._model;
            }

            protected Builder(TModel model)
            {
                _model = model;
            }

            public virtual TModel ToModel()
            {
                return _model;
            }

            public TBuilder Property<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, Action<List<string>> render)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _model._propertyRender[propertyInfo.Name] = render;
                }
                return (TBuilder)this;
            }

            public TBuilder Property<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, Action<List<string>, TProperty> render)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _model._propertyRender[propertyInfo.Name] = render;
                }
                return (TBuilder)this;
            }

            public TBuilder Ignore<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda)
            {
                var propertyInfo = GetPropertyInfo(propertyLambda);
                if (propertyInfo != null)
                {
                    _model._propertyRender[propertyInfo.Name] = null;
                }
                return (TBuilder)this;
            }

            /// <summary>
            /// Render the value of property from the text in the file as is.
            /// </summary>
            /// <typeparam name="TProperty"></typeparam>
            /// <param name="propertyLambda"></param>
            /// <param name="path"></param>
            /// <returns></returns>
            public TBuilder File<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, string path)
            {
                return (TBuilder)this;
            }

            /// <summary>
            /// Render the value of property from the text in the view as is.
            /// </summary>
            /// <typeparam name="TProperty"></typeparam>
            /// <param name="propertyLambda"></param>
            /// <param name="path"></param>
            /// <returns></returns>
            public TBuilder View<TProperty>(Expression<Func<TModel, TProperty>> propertyLambda, string path)
            {
                return (TBuilder)this;
            }

            /// <summary>
            /// Set the master view path
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public TBuilder Master(string path)
            {
                _master = path;
                return (TBuilder)this;
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
        }
    }
}