using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class FileProcesses
    {
        public static Node[] Children(this File file)
        {
            return new Node[0];
        }
    }
}
