using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Custom.Presentation
{
    using Utilities;
    using Newtonsoft.Json.Linq;
    using System.Globalization;
    using System.IO;

    public abstract class Scriptable : IScriptable
    {
        private string _id;
        private string _dynamicID;

        protected Scriptable()
        {
        }

        protected virtual bool IsEmpty
        {
            get { return false; }
        }

        #region - IScriptable -

        bool IScriptable.IsEmpty
        {
            get { return this.IsEmpty; }
        }

        string IScriptable.Template
        {
            get;
            set;
        }

        void IScriptable.Script(ScriptWriter writer)
        {
            var serializer = CreateSerializer();
            if (serializer != null)
                serializer.Serialize(writer);
        }

        #endregion - IScriptable -

        protected abstract IScriptSerializer CreateSerializer();

        [Description("")]
        protected string DynamicID
        {
            get
            {
                if (_dynamicID.IsEmpty())
                {
                    _dynamicID = GenerateID();
                }
                return _dynamicID;
            }
        }

        public Unit Height
        {
            get;
            set;
        }

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Namespace
        {
            get;
            set;
        }

        protected virtual string FormatValue(object value, string format)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return Convert.ToString(value, CultureInfo.CurrentCulture);
            }
            return string.Format(CultureInfo.CurrentCulture, format, new object[] { value });
        }

        public static string GenerateID()
        {
            long num = 1L;
            foreach (byte num2 in Guid.NewGuid().ToByteArray())
            {
                num *= num2 + 1;
            }
            return string.Format("id{0:x}", num - DateTime.Now.Ticks);
        }

        public class Builder<TModel, TBuilder> : ScriptBuilder<TModel, TBuilder>
            where TModel : Scriptable
            where TBuilder : Scriptable.Builder<TModel, TBuilder>
        {
            public Builder(TModel obj)
                : base(obj)
            {
            }

            public virtual TBuilder Namespace(string ns)
            {
                ToModel().Namespace = ns;
                return (this as TBuilder);
            }
        }

        public abstract class Serializer<TModel, TSerializer> : ScriptSerializer<TModel, TSerializer>
            where TModel : Scriptable
            where TSerializer : Scriptable.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}