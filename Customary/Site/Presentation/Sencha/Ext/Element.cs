using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext
{
    /// <summary>
    /// Encapsulates a DOM element, adding simple DOM manipulation facilities, normalizing for browser differences.
    /// </summary>
    public class Element
    {
        public enum Events
        {
            DOMActivate,

            DOMAttrModified
        }
    }
}