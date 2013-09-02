using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    /// <summary>
    /// Job that will execute async at a given time, or by request of a given Action. Local to Area
    /// </summary>
    public class Job
    {
        public IEnumerable<Task> Tasks { get; set; }

        public DateTime Start { get; set; }

        public IEnumerable<Worker> Workers { get; set; }
    }
}
