using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Raven.Replication
{
    public class Destination
    {
        /// <summary>
        /// A RavenDB instance where to replicate to.
        /// It's format is as follows: "http://raven_two:8080/"
        /// </summary>
        public string Url
        {
            get;
            set;
        }
    }
}