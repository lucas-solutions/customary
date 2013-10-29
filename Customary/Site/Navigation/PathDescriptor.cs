using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Navigation
{
    using Newtonsoft.Json;

    public class PathDescriptor
    {
        public string Name { get; set; }

        public List<PathDescriptor> Children { get; set; }

        [JsonIgnore]
        public PathDescriptor Parent { get; set; }

        /// <summary>
        /// MVC Area for this segment
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// MVC Controller handling this segment
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Predefined parameter values when calling Action.
        /// These will be put in the RouteData
        /// </summary>
        public Dictionary<string, object> Params { get; set; }

        /// <summary>
        /// Resource id for displaying page
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string Presenter { get; set; }

        /// <summary>
        /// Server reference for data (SQL DB or Services)
        /// </summary>
        public string Server { get; set; }
    }
}