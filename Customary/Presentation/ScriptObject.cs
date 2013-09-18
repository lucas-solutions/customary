using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Custom.Presentation
{
    using Utilities;
    using Newtonsoft.Json.Linq;

    public abstract partial class ScriptObject
    {
        public static implicit operator Scriptable(ScriptObject script)
        {
            return script.ToScriptable();
        }

        private string _id;
        private string _dynamicID;

        protected ScriptObject()
        {
            var arr = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propInfo in arr)
            {
                var defaultValue = propInfo.GetCustomAttribute<DefaultValueAttribute>(true);
                if (defaultValue != null)
                {
                    var setter = propInfo.GetSetMethod();
                    if (setter != null)
                    {
                        setter.Invoke(this, new object[] { defaultValue.Value });
                    }
                }
            }
        }

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

        protected abstract Scriptable ToScriptable();
    }
}