using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    /// <summary>
    /// Ext tree node format
    /// </summary>
    public class Node
    {
        public bool? allowDrag;

        public bool? leaf;

        public string name;

        public string text;

        public string type;

        public object raw;

        public Node[] children;
    }
}
