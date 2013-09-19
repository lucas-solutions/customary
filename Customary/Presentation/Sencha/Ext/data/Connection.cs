using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    [Ext("Ext.data.Connection")]
    public abstract class Connection : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.data.Connection model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }

        /// <summary>
        /// True to enable CORS support on the XHR object. Currently the only effect of this option is to use the XDomainRequest object instead of XMLHttpRequest if the browser is IE8 or above.
        /// </summary>
        [DefaultValue(false)]
        public bool Cors
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
        /// Change the parameter which is sent went disabling caching through a cache buster.
        /// </summary>
        [DefaultValue("_dc")]
        public string DisableCachingParam
        {
            get;
            set;
        }

        /// <summary>
        /// Any parameters to be appended to the request.
        /// </summary>
        public object ExtraParams
        {
            get;
            set;
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests
        /// </summary>
        [DefaultValue(30000)]
        public int Timeout
        {
            get;
            set;
        }

        /// <summary>
        /// True to set withCredentials = true on the XHR object.
        /// </summary>
        [DefaultValue(false)]
        public bool WithCredentials
        {
            get;
            set;
        }

        public enum Events
        {
            /// <summary>
            /// Fires before a network request is made to retrieve a data object.
            /// </summary>
            Beforerequest,

            /// <summary>
            /// Fires if the request was successfully completed.
            /// </summary>
            Requestcomplete,

            /// <summary>
            /// Fires if an error HTTP status was returned from the server. See HTTP Status Code Definitions for details of HTTP status codes.
            /// </summary>
            Requestexception
        }
    }
}