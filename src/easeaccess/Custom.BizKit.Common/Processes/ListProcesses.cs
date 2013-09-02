using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class ListProcesses
    {
        public static Node[] Children(this List list)
        {
            return new[]
                {
                    new Node
                    {
                        name = "Items",
                        text = "Items",
                        type = "items"
                    }
                };
        }

        public static Node[] RowsChildren(this List list)
        {
            return list.Items.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "item"
            }).ToArray();
        }
    }
}
