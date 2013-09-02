using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class NoteProcesses
    {
        public static Node[] Children(this Note note)
        {
            return new Node[0];
        }
    }
}
