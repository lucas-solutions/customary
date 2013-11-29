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
    using Newtonsoft.Json.Linq;

    public abstract partial class ScriptObject : Scriptable
    {
        private Dictionary<string, Delegate> _propertyRender;

        protected ScriptObject()
        {
            _propertyRender = new Dictionary<string, Delegate>();

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

        public override void Render(List<string> lines)
        {
            RenderObject(this, _propertyRender, lines);
        }

        public override void Write(TextWriter writer)
        {
            var lines = new List<string>();
            Render(lines);
            writer.WriteAllLines(lines);
        }
    }
}