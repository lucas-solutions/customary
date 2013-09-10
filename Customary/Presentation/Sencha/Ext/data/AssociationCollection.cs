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

        public AssociationCollection Add(string name, string model, AssociationTypes type)
        {
            Items.Add(new Association { Name = name, Model = model, Type = type });
            return this;
        }

        public AssociationCollection BelongsTo(string name)
        {
            Items.Add(new Association { Name = name, Type = AssociationTypes.belongsTo });
            return this;
        }

        public AssociationCollection HasMany(string name, string model)
        {
            Items.Add(new Association { Name = name, Model = model, Type = AssociationTypes.hasMany });
            return this;
        }

        public AssociationCollection HasOne(string name, string model)
        {
            Items.Add(new Association { Name = name, Model = model, Type = AssociationTypes.hasOne });
            return this;
        }
    }
}