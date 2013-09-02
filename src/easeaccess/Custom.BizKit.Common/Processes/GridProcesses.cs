using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class GridProcesses
    {
        public static Node[] Children(this Grid grid)
        {
            return new[]
                {
                    new Node
                    {
                        leaf = true,
                        name = "Columns",
                        text = "Columns",
                        type = "columns"
                    },
                    new Node
                    {
                        leaf = true,
                        name = "Rows",
                        text = "Rows",
                        type = "rows"
                    }
                };
        }

        public static Node[] ColumnsChildren(this Grid grid)
        {
            return grid.Columns.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "column"
            }).ToArray();
        }

        /*public static Node[] RowsChildren(this Grid grid)
        {
            return grid.Rows.Select(o => new Node
            {
                leaf = true,
                name = o.Name,
                text = o.Name,
                type = "row"
            }).ToArray();
        }*/
    }
}
