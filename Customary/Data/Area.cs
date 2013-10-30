using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    public class Area : Node
    {
        private ICollection<Directory> _children;

        public Area()
            : base(null)
        {
        }

        public Area(Area parent)
            : base(parent)
        {
        }

        private void Freeze()
        {
            if (_children != null)
            {
                var children = _children.ToArray();

                Array.Sort(children, Compare);

                foreach (var child in children)
                    child.Freeze();

                _children = children;
            }
        }
    }
}