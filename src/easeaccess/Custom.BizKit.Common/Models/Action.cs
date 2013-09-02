using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    /// <summary>
    /// Start async process. Local to area.
    /// </summary>
    public class Action
    {
        private List<Text> _title;

        public List<Text> Title
        {
            get { return _title ?? (_title = new List<Text>()); }
            set { _title = value; }
        }
    }
}
