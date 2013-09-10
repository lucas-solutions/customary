using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class FieldCollection
    {
        public List<Field> _items;

        public int Count
        {
            get { return _items != null ? _items.Count : 0; }
        }

        public List<Field> Items
        {
            get { return _items ?? (_items = new List<Field>()); }
        }

        public FieldCollection Add(Field item)
        {
            Items.Add(item);
            return this;
        }

        public FieldCollection Add(string name)
        {
            Items.Add(new Field { Name = name });
            return this;
        }

        public FieldCollection Add(string name, string type)
        {
            Items.Add(new Field { Name = name, Type = type });
            return this;
        }

        public FieldCollection Add(string name, string type, JFunction covert)
        {
            Items.Add(new Field { Name = name, Type = type, Convert = covert });
            return this;
        }

        public Field.Builder Builder()
        {
            var item = new Field();
            Items.Add(item);
            return new Field.Builder(item);
        }
    }
}