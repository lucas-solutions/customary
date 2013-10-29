using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public partial class ScriptArray<TArray, TItem> : Scriptable
        where TArray : ScriptArray<TArray, TItem>
        where TItem : class
    {
        public List<TItem> _items;

        public int Count
        {
            get { return _items != null ? _items.Count : 0; }
        }

        public List<TItem> Items
        {
            get { return _items ?? (_items = new List<TItem>()); }
        }

        public TArray Add(TItem item)
        {
            Items.Add(item);
            return (TArray)this;
        }

        public TArray Add(IEnumerable<TItem> collection)
        {
            foreach (var item in collection)
            {
                Items.Add(item);
            }
            return (TArray)this;
        }

        public override void Render(List<string> lines)
        {
            var count = Count;

            if (count == 0)
                return;

            RenderEnumerable(Items, lines);
        }
    }
}