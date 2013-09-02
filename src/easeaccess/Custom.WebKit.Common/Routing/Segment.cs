using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Routing
{
    public class Segment<T>
        where T : class, new()
    {
        public T Entity
        {
            get;
            set;
        }
    }
}
