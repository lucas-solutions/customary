using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class ValidationsCollection
    {
        public List<Validations> _items;

        public int Count
        {
            get { return _items != null ? _items.Count : 0; }
        }

        public List<Validations> Items
        {
            get { return _items ?? (_items = new List<Validations>()); }
        }

        public ValidationsCollection Add(Validations item)
        {
            Items.Add(item);
            return this;
        }

        public ValidationsCollection Add(IEnumerable<Ext.data.Validations> collection)
        {
            foreach (var item in collection)
            {
                Items.Add(item);
            }
            return this;
        }

        

        public ValidationsCollection Add(ValidationTypes type, string field, int? min, string[] list, string matcher)
        {
            Items.Add(new Validations { Type = type, Field = field, Min = min, List = list, Matcher = matcher });
            return this;
        }

        public ValidationsCollection Exclusion(string field, string[] list)
        {
            Items.Add(new Validations { Type = ValidationTypes.exclusion, Field = field, List = list });
            return this;
        }

        public ValidationsCollection Format(string field, string matcher)
        {
            Items.Add(new Validations { Type = ValidationTypes.format, Field = field, Matcher = matcher });
            return this;
        }

        public ValidationsCollection Inclusion(string field, string[] list)
        {
            Items.Add(new Validations { Type = ValidationTypes.inclusion, Field = field, List = list });
            return this;
        }

        public ValidationsCollection Length(string field, int min)
        {
            Items.Add(new Validations { Type = ValidationTypes.length, Field = field, Min = min });
            return this;
        }

        public ValidationsCollection Presence(string field)
        {
            Items.Add(new Validations { Type = ValidationTypes.presence, Field = field });
            return this;
        }
    }
}