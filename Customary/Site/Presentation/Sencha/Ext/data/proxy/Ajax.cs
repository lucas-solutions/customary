using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data.proxy
{
    public partial class Ajax : Ext.data.proxy.Server
    {
        /// <summary>
        /// Mapping of action name to HTTP request method. In the basic AjaxProxy these are set to 'GET' for 'read' actions and 'POST' for 'create', 'update' and 'destroy' actions. The Ext.data.proxy.Rest maps these to the correct RESTful methods.
        /// Defaults to: {create: 'POST', read: 'GET', update: 'POST', destroy: 'POST'}
        /// </summary>
        public Dictionary<string, string> ActionMethods
        {
            get;
            set;
        }

        /// <summary>
        /// Any headers to add to the Ajax request. Defaults to undefined.
        /// </summary>
        public Dictionary<string, string> Headers
        {
            get;
            set;
        }
    }
}