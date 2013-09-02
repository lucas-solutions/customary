using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Custom.Models;

    public static class FormExtensions
    {
        public static Field Get(this Model self, Field field)
        {
            return null;
        }

        public static void Merge(this Model self, Model other)
        {
        }

        public static void Store (this Model self, Field field)
        {
            var current = self.Fields.SingleOrDefault(o => o.Name == field.Name);

            if (current != null)
            {
                current.Merge(field);
            }
            else
            {
                self.Fields.Add(field);
            }
        }
    }
}
