using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    [System.ComponentModel.Description("")]
    public class ClientConfig
    {
        private System.Collections.Generic.List<string> exclude = new System.Collections.Generic.List<string>();
        private System.Web.UI.Control owner;
        private System.Text.StringBuilder sb;
        private System.IO.StringWriter sw;
        private JsonTextWriter writer;

        private SerializationOptions ConfigOptionAttr2SerializationOptions(ConfigOptionAttribute attr)
        {
            if (attr.JsonConverter != null)
            {
                return new SerializationOptions(attr.Name, attr.JsonConverter);
            }
            return new SerializationOptions(attr.Name, attr.Mode);
        }

        public static ConfigOptionAttribute GetClientConfigAttribute(System.Reflection.PropertyInfo property)
        {
            object[] customAttributes = property.GetCustomAttributes(typeof(ConfigOptionAttribute), true);
            if (customAttributes.Length == 1)
            {
                return (ConfigOptionAttribute)customAttributes[0];
            }
            return null;
        }

        private string GetInstanceOf(object originalValue)
        {
            if (originalValue is BaseControl)
            {
                return ((BaseControl)originalValue).InstanceOf;
            }
            if ((originalValue is BaseItem) && !(originalValue is IAlias))
            {
                return ((BaseItem)originalValue).InstanceOf;
            }
            return "";
        }

        private static ConfigProperties GetProperties(object obj)
        {
            string str = obj.GetType().get_FullName();
            ConfigProperties properties = null;
            System.Web.HttpContext current = System.Web.HttpContext.Current;
            if (current != null)
            {
                properties = current.Cache.get_Item(str) as ConfigProperties;
            }
            if (properties != null)
            {
                return properties;
            }
            System.Reflection.PropertyInfo[] infoArray = obj.GetType().GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            ConfigProperties properties2 = new ConfigProperties();
            System.Reflection.PropertyInfo[] infoArray2 = infoArray;
            for (int i = 0; i < infoArray2.Length; i = (int)(i + 1))
            {
                System.Reflection.PropertyInfo property = infoArray2[i];
                ConfigOptionAttribute clientConfigAttribute = GetClientConfigAttribute(property);
                if (clientConfigAttribute != null)
                {
                    properties2.Add(new ConfigObject(property, clientConfigAttribute, ReflectionUtils.GetDefaultValue((System.Reflection.PropertyInfo)property)));
                }
            }
            properties2.Reverse();
            if (current != null)
            {
                current.Cache.Insert(str, properties2);
            }
            return properties2;
        }

        [System.ComponentModel.Description("")]
        public static bool IsEmptyObject(string value)
        {
            if (!value.IsEmpty() && !value.Equals("{}"))
            {
                return value.Equals("[]");
            }
            return true;
        }

        public bool IsNullEmptyOrDefault(ref object defaultValue, ref object originalValue, ConfigOption configOption)
        {
            if (defaultValue == null)
            {
                defaultValue = "NULL";
            }
            if (originalValue == null)
            {
                originalValue = "NULL";
            }
            else
            {
                if (((configOption.Serialization.Mode == JsonMode.Custom) && (configOption.Serialization.JsonConverter == typeof(LazyControlJsonConverter))) && ((originalValue is System.Web.UI.Control) && !((System.Web.UI.Control)originalValue).get_Visible()))
                {
                    return true;
                }
                if (!(originalValue is string) && (originalValue is System.Collections.IEnumerable))
                {
                    if (!((System.Collections.IEnumerable)originalValue).GetEnumerator().MoveNext())
                    {
                        originalValue = "NULL";
                    }
                }
                else if (originalValue is System.DateTime)
                {
                    System.DateTime time = (System.DateTime)originalValue;
                    if (time.Equals(System.DateTime.MinValue) || time.Equals(System.DateTime.MaxValue))
                    {
                        return true;
                    }
                }
                else if (originalValue is System.Web.UI.WebControls.Unit)
                {
                    System.Web.UI.WebControls.Unit unit = (System.Web.UI.WebControls.Unit)defaultValue;
                    System.Web.UI.WebControls.Unit unit2 = (System.Web.UI.WebControls.Unit)originalValue;
                    if (unit2.get_IsEmpty() || unit.Equals(originalValue))
                    {
                        return true;
                    }
                }
                else
                {
                    if (originalValue is BaseControl)
                    {
                        return ((BaseControl)originalValue).IsDefault;
                    }
                    if (originalValue is BaseItem)
                    {
                        return ((BaseItem)originalValue).IsDefault;
                    }
                    if (originalValue is Margins)
                    {
                        return ((Margins)originalValue).IsDefault;
                    }
                }
            }
            return defaultValue.Equals(originalValue);
        }

        private void Process(object obj)
        {
            IXObject obj2 = obj as IXObject;
            if ((obj2 != null) && (obj2.ConfigOptionsExtraction == ConfigOptionsExtraction.List))
            {
                ConfigOptionsCollection configOptions = obj2.ConfigOptions;
                foreach (System.Collections.Generic.KeyValuePair<int, ConfigOption> pair in configOptions.PriorityProperties)
                {
                    try
                    {
                        this.ToExtConfig(obj, pair.Value);
                    }
                    catch (System.Exception exception)
                    {
                        throw new System.Exception("Error during ClientConfig initialization. " + pair.Value.PropertyName.ToTitleCase() + " - " + exception.get_Message(), exception);
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<string, ConfigOption> pair2 in configOptions)
                {
                    try
                    {
                        this.ToExtConfig(obj, pair2.Value);
                    }
                    catch (System.Exception exception2)
                    {
                        throw new System.Exception("Error during ClientConfig initialization. " + pair2.Value.PropertyName.ToTitleCase() + " - " + exception2.get_Message(), exception2);
                    }
                }
            }
            else
            {
                foreach (ConfigObject obj3 in GetProperties(obj))
                {
                    try
                    {
                        this.ToExtConfig(obj, new ConfigOption(obj3.PropertyInfo.get_Name(), this.ConfigOptionAttr2SerializationOptions(obj3.Attribute), obj3.DefaultValue, obj3.PropertyInfo.GetValue(obj, null)));
                    }
                    catch (System.Exception exception3)
                    {
                        throw new System.Exception("Error during ClientConfig initialization. " + obj3.PropertyInfo.get_Name() + " - " + exception3.get_Message(), exception3);
                    }
                }
            }
        }

        [System.ComponentModel.Description("")]
        public string Serialize(object obj)
        {
            return this.Serialize(obj, false);
        }

        [System.ComponentModel.Description("")]
        public string Serialize(object obj, bool ignoreCustomSerialization)
        {
            bool quoteName = true;
            object obj2 = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Items.get_Item("ExtNetInitScriptFilter") : true;
            if ((obj2 != null) && ((bool)obj2))
            {
                quoteName = false;
            }
            return this.Serialize(obj, ignoreCustomSerialization, quoteName);
        }

        [System.ComponentModel.Description("")]
        public string Serialize(object obj, bool ignoreCustomSerialization, bool quoteName)
        {
            BaseItem item = obj as BaseItem;
            if (this.owner == null)
            {
                if (obj is System.Web.UI.Control)
                {
                    this.owner = (System.Web.UI.Control)obj;
                    if (obj is Observable)
                    {
                        foreach (ConfigItem item2 in ((Observable)obj).CustomConfig)
                        {
                            this.exclude.Add(item2.Name);
                        }
                    }
                }
                else if (item != null)
                {
                    this.owner = item.Owner;
                }
            }
            if (item != null)
            {
                item.BeforeSerialization();
            }
            if ((obj is ICustomConfigSerialization) && !ignoreCustomSerialization)
            {
                return (obj as ICustomConfigSerialization).ToScript(this.owner);
            }
            this.sb = new System.Text.StringBuilder();
            this.sw = new System.IO.StringWriter(this.sb);
            this.writer = new JsonTextWriter(this.sw);
            this.writer.set_QuoteName(quoteName ? ((bool)true) : ((bool)(obj is IQuotable)));
            if (this.owner is BaseControl)
            {
                BaseControl owner = (BaseControl)this.owner;
                if (owner != null)
                {
                    ResourceManager safeResourceManager = null;
                    safeResourceManager = owner.SafeResourceManager;
                    if ((safeResourceManager != null) && safeResourceManager.SourceFormatting)
                    {
                        this.writer.set_Formatting(Formatting.Indented);
                    }
                }
            }
            this.writer.WriteStartObject();
            this.Process(obj);
            this.writer.WriteEndObject();
            this.writer.Flush();
            return this.sw.GetStringBuilder().ToString();
        }

        internal string SerializeInternal(object obj, System.Web.UI.Control owner)
        {
            this.owner = owner;
            BaseItem item = obj as BaseItem;
            if (item != null)
            {
                item.Owner = owner;
            }
            return this.Serialize(obj);
        }

        private void ToExtConfig(object obj, ConfigOption configOption)
        {
            if (configOption.Serialization.Mode != JsonMode.Ignore)
            {
                System.Action<System.Reflection.PropertyInfo> action = null;
                object originalValue = configOption.Value;
                object defaultValue = configOption.DefaultValue;
                if (!this.IsNullEmptyOrDefault(ref defaultValue, ref originalValue, configOption))
                {
                    if (originalValue.Equals("NULL"))
                    {
                        originalValue = null;
                    }
                    string name = configOption.PropertyName.ToLowerCamelCase();
                    if (configOption.Serialization.Name.IsNotEmpty())
                    {
                        if (configOption.Serialization.Name.Contains(">"))
                        {
                            string[] strArray = configOption.Serialization.Name.Split((char[])new char[] { '>' });
                            name = strArray[0];
                            System.Reflection.PropertyInfo property = originalValue.GetType().GetProperty(strArray[1]);
                            ConfigOptionAttribute clientConfigAttribute = GetClientConfigAttribute(property);
                            if (clientConfigAttribute != null)
                            {
                                configOption.Serialization = this.ConfigOptionAttr2SerializationOptions(clientConfigAttribute);
                                originalValue = property.GetValue(originalValue, null);
                            }
                        }
                        else
                        {
                            name = configOption.Serialization.Name;
                        }
                    }
                    if (!this.exclude.Contains(name))
                    {
                        System.Web.UI.Control control;
                        string str4;
                        bool flag3;
                        System.Text.StringBuilder builder = new System.Text.StringBuilder(0x80);
                        switch (configOption.Serialization.Mode)
                        {
                            case JsonMode.Array:
                            case JsonMode.AlwaysArray:
                                if (originalValue is System.Collections.IEnumerable)
                                {
                                    System.Collections.IList list = (System.Collections.IList)originalValue;
                                    if ((list.get_Count() != 1) || (configOption.Serialization.Mode == JsonMode.AlwaysArray))
                                    {
                                        bool flag = false;
                                        builder.Append("[");
                                        foreach (object obj4 in list)
                                        {
                                            if (flag)
                                            {
                                                builder.Append(",");
                                            }
                                            if (obj4.GetType().get_IsPrimitive() || (obj4 is string))
                                            {
                                                builder.Append(JSON.Serialize(obj4));
                                            }
                                            else
                                            {
                                                builder.Append(new ClientConfig().SerializeInternal(obj4, this.owner));
                                            }
                                            flag = true;
                                        }
                                        builder.Append("]");
                                        string instanceOf = this.GetInstanceOf(originalValue);
                                        if (instanceOf.IsNotEmpty())
                                        {
                                            this.WriteRawValue(name, "new {0}({1})".FormatWith((object[])new object[] { instanceOf, builder.ToString() }));
                                            return;
                                        }
                                        this.WriteRawValue(name, builder.ToString());
                                        return;
                                    }
                                    if (list.get_Item(0) == null)
                                    {
                                        builder.Append("null");
                                    }
                                    if (list.get_Item(0).GetType().get_IsPrimitive() || (list.get_Item(0) is string))
                                    {
                                        builder.Append(JSON.Serialize(list.get_Item(0)));
                                    }
                                    else
                                    {
                                        builder.Append(new ClientConfig().SerializeInternal(list.get_Item(0), this.owner));
                                    }
                                    if (IsEmptyObject(builder.ToString()))
                                    {
                                        return;
                                    }
                                    this.WriteRawValue(name, builder.ToString());
                                }
                                return;

                            case JsonMode.ArrayToObject:
                                if (originalValue is System.Collections.IEnumerable)
                                {
                                    System.Collections.IList list2 = (System.Collections.IList)originalValue;
                                    builder.Append("{");
                                    bool flag2 = false;
                                    foreach (object obj5 in list2)
                                    {
                                        if (flag2)
                                        {
                                            builder.Append(",");
                                        }
                                        builder.Append(obj5.ToString());
                                        flag2 = true;
                                    }
                                    builder.Append("}");
                                    if (IsEmptyObject(builder.ToString()))
                                    {
                                        return;
                                    }
                                    this.WriteRawValue(name, builder.ToString());
                                }
                                return;

                            case JsonMode.Custom:
                                if ((originalValue != null) && (!(originalValue is System.Collections.IList) || (((System.Collections.IList)originalValue).get_Count() != 0)))
                                {
                                    if (name != "-")
                                    {
                                        this.writer.WritePropertyName(name);
                                    }
                                    ExtJsonConverter converter = (ExtJsonConverter)System.Activator.CreateInstance(configOption.Serialization.JsonConverter);
                                    converter.Name = name;
                                    converter.PropertyName = configOption.PropertyName.ToTitleCase((System.Globalization.CultureInfo)System.Globalization.CultureInfo.InvariantCulture);
                                    converter.Owner = obj;
                                    converter.WriteJson(this.writer, originalValue, null);
                                    return;
                                }
                                return;

                            case JsonMode.Object:
                            case JsonMode.ObjectAllowEmpty:
                                builder.Append(new ClientConfig().SerializeInternal(originalValue, this.owner));
                                if (!IsEmptyObject(builder.ToString()) || (configOption.Serialization.Mode == JsonMode.ObjectAllowEmpty))
                                {
                                    string text = this.GetInstanceOf(originalValue);
                                    if (!text.IsNotEmpty())
                                    {
                                        this.WriteRawValue(name, builder.ToString());
                                        return;
                                    }
                                    this.WriteRawValue(name, "new {0}({1})".FormatWith((object[])new object[] { text, builder.ToString() }));
                                }
                                return;

                            case JsonMode.Raw:
                                this.WriteRawValue(name, originalValue);
                                return;

                            case JsonMode.ToLower:
                                this.WriteValue(name, originalValue.ToString().ToLowerInvariant());
                                return;

                            case JsonMode.ToCamelLower:
                                this.WriteValue(name, originalValue.ToString().ToLowerCamelCase());
                                return;

                            case JsonMode.UnrollCollection:
                                {
                                    System.Collections.IEnumerable enumerable = (System.Collections.IEnumerable)originalValue;
                                    foreach (object obj3 in enumerable)
                                    {
                                        if (obj3 != null)
                                        {
                                            this.Process(obj3);
                                        }
                                    }
                                    return;
                                }
                            case JsonMode.UnrollObject:
                                this.Process(originalValue);
                                return;

                            case JsonMode.Reflection:
                                if (originalValue != null)
                                {
                                    if (action == null)
                                    {
                                        action = x => this.WriteRawValue(x.get_Name().ToLowerCamelCase(), JSON.Serialize(x.GetValue(originalValue, null), new CamelCasePropertyNamesContractResolver()));
                                    }
                                    originalValue.GetType().GetProperties().Each<System.Reflection.PropertyInfo>((System.Action<System.Reflection.PropertyInfo>)action);
                                }
                                return;

                            case JsonMode.ToString:
                                this.WriteValue(name, (originalValue != null) ? ((object)originalValue.ToString()) : ((object)""));
                                return;

                            case JsonMode.ToClientID:
                                control = null;
                                str4 = "";
                                flag3 = false;
                                if (!(originalValue is System.Web.UI.Control))
                                {
                                    str4 = (string)(originalValue.ToString() ?? "");
                                    if (str4.StartsWith("{raw}"))
                                    {
                                        str4 = str4.Substring(5);
                                        flag3 = true;
                                    }
                                    else
                                    {
                                        control = (System.Web.UI.Control)ControlUtils.FindControl((System.Web.UI.Control)this.owner, str4, true);
                                    }
                                    break;
                                }
                                control = (System.Web.UI.Control)originalValue;
                                break;

                            case JsonMode.Url:
                                {
                                    string url = originalValue.ToString();
                                    this.WriteValue(name, (this.owner == null) ? url : ExtNetTransformer.ResolveUrl(url));
                                    return;
                                }
                            case JsonMode.Serialize:
                                this.WriteRawValue(name, JSON.Serialize(originalValue));
                                return;

                            default:
                                this.WriteValue(name, originalValue);
                                return;
                        }
                        if (name.StartsWith("{raw}"))
                        {
                            name = name.Substring(5);
                            flag3 = true;
                        }
                        if (control != null)
                        {
                            if (flag3)
                            {
                                this.WriteRawValue(name, "window." + control.get_ClientID());
                            }
                            else
                            {
                                this.WriteValue(name, (control is BaseControl) ? ((BaseControl)control).ConfigID : control.get_ClientID());
                            }
                        }
                        else
                        {
                            if (!flag3 && str4.Contains("."))
                            {
                                flag3 = true;
                            }
                            if (flag3)
                            {
                                this.WriteRawValue(name, str4);
                            }
                            else
                            {
                                this.WriteValue(name, str4);
                            }
                        }
                    }
                }
            }
        }

        private void WriteRawValue(string name, object value)
        {
            this.WriteRawValue(name, value, true);
        }

        private void WriteRawValue(string name, object value, bool parseTokens)
        {
            this.writer.WritePropertyName(name);
            if (value is string)
            {
                value = TokenUtils.ParseTokens(value.ToString(), this.owner);
            }
            else if (value is IScriptable)
            {
                value = ((IScriptable)value).ToScript();
            }
            string script = value.ToString();
            this.writer.WriteRawValue(TokenUtils.IsRawToken(script) ? TokenUtils.ReplaceRawToken(script) : script);
        }

        private void WriteValue(string name, object value)
        {
            if (value is string)
            {
                value = TokenUtils.ParseTokens(value.ToString(), this.owner);
                string script = value.ToString();
                if (script.StartsWith("<string>"))
                {
                    int num = 8;
                    string rawMarker = TokenUtils.Settings.RawMarker;
                    if (script.StartsWith("<string>" + rawMarker))
                    {
                        num = (int)(num + rawMarker.get_Length());
                    }
                    this.writer.WritePropertyName(name);
                    this.writer.WriteValue(script.Substring(num));
                    return;
                }
                if (TokenUtils.IsRawToken(script))
                {
                    this.WriteRawValue(name, TokenUtils.ReplaceRawToken(script));
                    return;
                }
            }
            this.writer.WritePropertyName(name);
            if (value is System.Web.UI.WebControls.Unit)
            {
                System.Web.UI.WebControls.Unit unit = (System.Web.UI.WebControls.Unit)value;
                if (unit.Type == System.Web.UI.WebControls.UnitType.Pixel)
                {
                    System.Web.UI.WebControls.Unit unit2 = (System.Web.UI.WebControls.Unit)value;
                    this.writer.WriteValue(System.Convert.ToInt32(unit2.get_Value()));
                }
                else if (unit.Type == System.Web.UI.WebControls.UnitType.Percentage)
                {
                    this.writer.WriteValue(((double)unit.get_Value()).ToString() + "%");
                }
            }
            else if (value is System.Enum)
            {
                this.writer.WriteValue(value.ToString());
            }
            else if (value is IScriptable)
            {
                this.writer.WriteValue(((IScriptable)value).ToScript());
            }
            else
            {
                this.writer.WriteValue(value);
            }
        }
    }
}