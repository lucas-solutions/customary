using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Presentation
{
    public abstract class ScriptBuilder
    {
        public static implicit operator MvcHtmlString(ScriptBuilder builder)
        {
            return builder != null ? new MvcHtmlString(builder.ToString()) : null;
        }

        public string ClassName
        {
            get;
            set;
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
    }

    public class ScriptBuilder<TModel, TBuilder> : IScriptBuilder<TModel>, IScriptBuilder, IHtmlString
        where TModel : Scriptable
        where TBuilder : ScriptBuilder<TModel, TBuilder>
    {
        private readonly TModel _model;

        public ScriptBuilder(TModel control)
        {
            this._model = control;
        }

        public T Cast<T>()
            where T : class, IScriptBuilder
        {
            return (this as T);
        }

        public virtual TBuilder ID(string id)
        {
            ToModel().ID = id;
            return (this as TBuilder);
        }

        public static implicit operator TModel(ScriptBuilder<TModel, TBuilder> builder)
        {
            return builder._model;
        }

        public virtual void Render(Scriptable obj)
        {
            //obj.Controls.Add(this.ToComponent());
        }

        public virtual TModel ToModel()
        {
            return _model;
        }

        // Properties
        public virtual UrlHelper UrlHelper
        {
            get
            {
                ViewContext viewContext = this.ViewContext;
                return new UrlHelper((viewContext != null) ? viewContext.RequestContext : new RequestContext(), RouteTable.Routes);
            }
        }

        public virtual ViewContext ViewContext
        {
            get
            {
                ViewContext viewContext = null;
                if (ToModel() is Scriptable)
                {
                    //viewContext = ((ScriptObject)ToObject()).ViewContext;
                }
                /*if ((viewContext == null) && (X.Builder.HtmlHelper != null))
                {
                    viewContext = X.Builder.HtmlHelper.ViewContext;
                }*/
                return viewContext;
            }
        }

        string IHtmlString.ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}