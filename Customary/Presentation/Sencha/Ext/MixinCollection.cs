using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public class MixinCollection : IScriptable
    {
        private List<string> _items;

        public List<string> Items
        {
            get { return _items ?? (_items = new List<string>()); }
        }

        void IScriptable.Render(List<string> lines)
        {
            if (_items != null && _items.Count > 0)
            {

            }
        }

        void IScriptable.Write(System.IO.TextWriter writer)
        {
            var lines = new List<string>();
            ((IScriptable)this).Render(lines);
            writer.WriteAllLines(lines);
        }
    }
}