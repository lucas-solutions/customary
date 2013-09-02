using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Job : Component
    {
        private Dictionary<string, string> _tasks;

        public Job(RavenJObject data, Component parent, string path)
            : base(data, parent, path)
        {
        }

        #region - mvc -

        public override string MvcControllerName
        {
            get { return "Job"; }
        }

        #endregion - mvc -
        
        /// <summary>
        /// Scheduled data and time
        /// </summary>
        public DateTime Start
        {
            get;
            set;
        }

        /// <summary>
        /// Gobal status for the job
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Tasks.
        /// The key is the task full name
        /// The value is the task status
        /// </summary>
        public Dictionary<string, string> Tasks
        {
            get { return _tasks ?? (_tasks = new Dictionary<string, string>()); }
            set { _tasks = value; }
        }
    }
}