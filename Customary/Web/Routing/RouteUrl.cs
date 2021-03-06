﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web.Routing
{
    /// <summary>
    /// Represents a generated route URL with route data.
    /// </summary>
    public class RouteUrl
    {
        /// <summary>
        /// Gets or sets the route URL.
        /// </summary>
        /// <value>Route URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets route values.
        /// </summary>
        /// <value>Route values.</value>
        public RouteValueDictionary Values { get; set; }
    }
}