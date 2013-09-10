using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    internal class ConfigObject
    {
        private ConfigOptionAttribute attr;
        private object defaultValue;
        private System.Reflection.PropertyInfo propertyInfo;

        [System.ComponentModel.Description("")]
        public ConfigObject(System.Reflection.PropertyInfo propertyInfo, ConfigOptionAttribute attr, object defValue)
        {
            this.propertyInfo = propertyInfo;
            this.attr = attr;
            this.defaultValue = defValue;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute Attribute
        {
            get
            {
                return this.attr;
            }
            set
            {
                this.attr = value;
            }
        }

        [System.ComponentModel.Description("")]
        public object DefaultValue
        {
            get
            {
                return this.defaultValue;
            }
            set
            {
                this.defaultValue = value;
            }
        }

        [System.ComponentModel.Description("")]
        public System.Reflection.PropertyInfo PropertyInfo
        {
            get
            {
                return this.propertyInfo;
            }
            set
            {
                this.propertyInfo = value;
            }
        }
    }
}