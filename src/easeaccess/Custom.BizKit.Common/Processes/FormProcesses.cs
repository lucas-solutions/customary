using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Models;

    public static class FormProcesses
    {
        public static Node[] Children(this Model form)
        {
            return new[]
                {
                    new Node
                    {
                        name = "Fields",
                        text = "Fields",
                        type = "fields"
                    }
                };
        }

        public static Node[] FieldsChildren(this Model form)
        {
            return form.Fields.Select(o => new Node
                    {
                        leaf = true,
                        name = o.Name,
                        text = o.Name,
                        type = "field"
                    }).ToArray();
        }
    }
}
