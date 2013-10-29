using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext
{
    public abstract class Ajax : Ext.data.Connection
    {
        private Builder _builder;

        /// <summary>
        /// Whether a new request should abort any pending requests.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoAbort
        {
            get;
            set;
        }

        /// <summary>
        /// An object containing request headers which are added to each request made by this object.
        /// </summary>
        public object DefaultHeaders
        {
            get;
            set;
        }

        /// <summary>
        /// True to add a unique cache-buster param to GET requests.
        /// </summary>
        [DefaultValue(true)]
        public bool DisableCaching
        {
            get;
            set;
        }

        /// <summary>
        /// An object containing properties which are used as extra parameters to each request made by this object. Session information and other data that you need to pass with each request are commonly put here.
        /// </summary>
        public object ExtraParams
        {
            get;
            set;
        }

        /// <summary>
        /// The default HTTP method to be used for requests. Note that this is case-sensitive and should be all caps (if not set but params are present will use "POST", otherwise will use "GET".)
        /// </summary>
        public string Method
        {
            get;
            set;
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests.
        /// </summary>
        [DefaultValue(30000)]
        public int Timeout
        {
            get;
            set;
        }

        /// <summary>
        /// The default URL to be used for requests to the server. If the server receives all requests through one URL, setting this once is easier than entering it on every request.
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder
        {
            public Builder(Ajax model)
            {
            }
        }
    }
}