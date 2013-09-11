using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class AssociationCollection
    {
        public List<Association> _items;

        public int Count
        {
            get { return _items != null ? _items.Count : 0; }
        }

        public List<Association> Items
        {
            get { return _items ?? (_items = new List<Association>()); }
        }

        public AssociationCollection Add(Association item)
        {
            Items.Add(item);
            return this;
        }

        public AssociationCollection BelongsTo(string name)
        {
            Items.Add(new BelongsToAssociation { Name = name });
            return this;
        }

        public AssociationCollection HasMany(string name, string model)
        {
            Items.Add(new HasManyAssociation { Name = name, AssociatedModel = model });
            return this;
        }
    }
}