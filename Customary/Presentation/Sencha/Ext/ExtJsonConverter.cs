using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;

    [System.ComponentModel.Description("")]
    public abstract class ExtJsonConverter : JsonConverter
    {
        private string name;
        private object owner;
        private string propertyName;

        protected ExtJsonConverter()
        {
        }

        [System.ComponentModel.Description("")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [System.ComponentModel.Description("")]
        public object Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        [System.ComponentModel.Description("")]
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
            set
            {
                this.propertyName = value;
            }
        }
    }
}