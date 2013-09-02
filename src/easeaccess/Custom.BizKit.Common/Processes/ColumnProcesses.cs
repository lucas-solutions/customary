using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class ColumnProcesses
    {
        public static Node[] Children(this Column column)
        {
            return new Node[0];
        }
    }
}
