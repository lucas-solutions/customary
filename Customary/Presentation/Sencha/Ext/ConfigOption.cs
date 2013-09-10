using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Custom.Presentation.Sencha.Ext.Utilities;
    using System;
    using System.ComponentModel;

    [System.ComponentModel.Description("")]
    public class ConfigOption
    {
        private static readonly SerializationOptions defaultSerialization = new SerializationOptions();
        private readonly object defaultValue;
        private readonly string propertyName;
        private SerializationOptions serialization;
        private readonly object value;

        [System.ComponentModel.Description("")]
        public ConfigOption(string propertyName, SerializationOptions serialization, object defaultValue, object value)
        {
            this.propertyName = propertyName;
            this.serialization = serialization;
            this.defaultValue = defaultValue;
            this.value = value;
        }

        [System.ComponentModel.Description("")]
        public object DefaultValue
        {
            get
            {
                return this.defaultValue;
            }
        }

        [System.ComponentModel.Description("")]
        public string Name
        {
            get
            {
                if ((this.Serialization != null) && this.Serialization.Name.IsNotEmpty())
                {
                    return this.Serialization.Name;
                }
                return this.PropertyName;
            }
        }

        [System.ComponentModel.Description("")]
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }

        [System.ComponentModel.Description("")]
        public SerializationOptions Serialization
        {
            get
            {
                return (this.serialization ?? defaultSerialization);
            }
            internal set
            {
                this.serialization = value;
            }
        }

        [System.ComponentModel.Description("")]
        public object Value
        {
            get
            {
                return this.value;
            }
        }
    }
}