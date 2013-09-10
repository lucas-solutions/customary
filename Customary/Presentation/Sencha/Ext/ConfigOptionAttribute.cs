using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using System.ComponentModel;

    [System.ComponentModel.Description(""), System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Enum | System.AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ConfigOptionAttribute : System.Attribute
    {
        private readonly System.Type jsonConverter;
        private readonly JsonMode mode;
        private readonly string name;
        private readonly int priority;

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute()
        {
            this.mode = JsonMode.Value;
            this.name = "";
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(JsonMode mode)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.mode = mode;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = name;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(System.Type jsonConverter)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = "";
            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new System.ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }
            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(JsonMode mode, int priority)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.mode = mode;
            this.priority = priority;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name, JsonMode mode)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = name;
            this.mode = mode;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name, int priority)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = name;
            this.priority = priority;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name, System.Type jsonConverter)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = name;
            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new System.ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }
            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(System.Type jsonConverter, int priority)
            : this(jsonConverter)
        {
            this.priority = priority;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name, JsonMode mode, int priority)
        {
            this.mode = JsonMode.Value;
            this.name = "";
            this.name = name;
            this.mode = mode;
            this.priority = priority;
        }

        [System.ComponentModel.Description("")]
        public ConfigOptionAttribute(string name, System.Type jsonConverter, int priority)
            : this(name, jsonConverter)
        {
            this.priority = priority;
        }

        [System.ComponentModel.Description("")]
        public System.Type JsonConverter
        {
            get
            {
                return this.jsonConverter;
            }
        }

        [System.ComponentModel.Description("")]
        public JsonMode Mode
        {
            get
            {
                return this.mode;
            }
        }

        [System.ComponentModel.Description("")]
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        [System.ComponentModel.Description("")]
        public int Priority
        {
            get
            {
                return this.priority;
            }
        }
    }
}