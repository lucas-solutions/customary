using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class ValidationCollection
    {
        public List<Validation> _items;

        public int Count
        {
            get { return _items != null ? _items.Count : 0; }
        }

        public List<Validation> Items
        {
            get { return _items ?? (_items = new List<Validation>()); }
        }

        public ValidationCollection Add(Validation item)
        {
            Items.Add(item);
            return this;
        }

        public ValidationCollection Add(IEnumerable<Ext.data.Validation> collection)
        {
            foreach (var item in collection)
            {
                Items.Add(item);
            }
            return this;
        }

        

        public ValidationCollection Add(ValidationTypes type, string field, int? min, string[] list, string matcher)
        {
            Items.Add(new Validation { Type = type, Field = field, Min = min, List = list, Matcher = matcher });
            return this;
        }

        public ValidationCollection Exclusion(string field, string[] list)
        {
            Items.Add(new Validation { Type = ValidationTypes.exclusion, Field = field, List = list });
            return this;
        }

        public ValidationCollection Format(string field, string matcher)
        {
            Items.Add(new Validation { Type = ValidationTypes.format, Field = field, Matcher = matcher });
            return this;
        }

        public ValidationCollection Inclusion(string field, string[] list)
        {
            Items.Add(new Validation { Type = ValidationTypes.inclusion, Field = field, List = list });
            return this;
        }

        public ValidationCollection Length(string field, int min)
        {
            Items.Add(new Validation { Type = ValidationTypes.length, Field = field, Min = min });
            return this;
        }

        public ValidationCollection Presence(string field)
        {
            Items.Add(new Validation { Type = ValidationTypes.presence, Field = field });
            return this;
        }
    }
}