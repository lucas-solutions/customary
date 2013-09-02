using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Utils
{
    public static class CollectionHelper
    {
        public static ICollection<T> CreateCollection<T>()
        {
            return new List<T>();
        }
    }
}
