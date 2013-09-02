using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class JobObject : ComponentObject
    {
        private List<TaskObject> _tasks;

        public List<TaskObject> Tasks
        {
            get { return _tasks ?? (_tasks = new List<TaskObject>()); }
            set { _tasks = value; }
        }
    }
}