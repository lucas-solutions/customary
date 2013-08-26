using System;
using System.Collections.Generic;

namespace Custom.Objects
{
    using Newtonsoft.Json;

    public class BusinessSegment
    {
        public string Name { get; set; }

        public List<BusinessSegment> Segments { get; set; }

        [JsonIgnore]
        public BusinessSegment Parent { get; set; }

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
        /// Server reference for data (SQL DB or Services)
        /// </summary>
        public string Server { get; set; }
    }
}