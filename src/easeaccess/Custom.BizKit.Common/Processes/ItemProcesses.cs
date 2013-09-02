using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class ItemProcesses
    {
        public static Node[] Children(this Item item)
        {
            return new Node[0];
        }
    }
}
