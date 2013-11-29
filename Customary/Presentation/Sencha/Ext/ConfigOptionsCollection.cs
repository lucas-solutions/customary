using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [System.ComponentModel.Description("")]
    public class ConfigOptionsCollection : System.Collections.Generic.Dictionary<string, ConfigOption>
    {
        private System.Collections.Generic.SortedDictionary<int, ConfigOption> priorityProperties = new System.Collections.Generic.SortedDictionary<int, ConfigOption>();

        [System.ComponentModel.Description("")]
        public void Add(string key, ConfigOption value)
        {
            if (value.Serialization.Priority != 0)
            {
                if (this.priorityProperties.ContainsKey(value.Serialization.Priority))
                {
                    this.priorityProperties.Remove(value.Serialization.Priority);
                }
                this.priorityProperties.Add(value.Serialization.Priority, value);
            }
            if (base.ContainsKey(key))
            {
                base.Remove(key);
            }
            if (value.Serialization.Priority == 0)
            {
                base.Add(key, value);
            }
        }

        [System.ComponentModel.Description("")]
        public virtual void Add(string propertyName, object defaultValue, object value)
        {
            this.Add(propertyName, new ConfigOption(propertyName, null, defaultValue, value));
        }

        [System.ComponentModel.Description("")]
        public System.Collections.Generic.SortedDictionary<int, ConfigOption> PriorityProperties
        {
            get
            {
                return this.priorityProperties;
            }
        }
    }
}