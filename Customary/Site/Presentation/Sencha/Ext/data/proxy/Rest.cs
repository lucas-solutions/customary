using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data.proxy
{
    public class Rest : Ext.data.proxy.Ajax
    {
        private Builder _builder;

        public Rest()
        {
            Type = "rest";
            /*ActionMethods = new Dictionary<string, string>
            {
                { "create", "POST" },
                { "read", "GET" },
                { "update", "PUT" },
                { "destroy", "DELETE" }
            };*/
        }

        /// <summary>
        /// True to automatically append the ID of a Model instance when performing a request based on that single instance. See Rest proxy intro docs for more details. Defaults to true.
        /// </summary>
        [DefaultValue(true)]
        public bool AppendId
        {
            get;
            set;
        }

        /// <summary>
        /// True to batch actions of a particular type when synchronizing the store.
        /// </summary>
        public new bool BatchActions
        {
            get;
            set;
        }

        /// <summary>
        /// Optional data format to send to the server when making any request (e.g. 'json'). See the Rest proxy intro docs for full details. Defaults to undefined.
        /// </summary>
        public string Format
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder : Builder<Rest, Builder>
        {
            public Builder(Rest model)
                : base(model)
            {
            }
        }
    }
}