using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data
{
    public class FieldCollection : ScriptArray<FieldCollection, Field>
    {
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

        public FieldCollection Add(string name, string type, ScriptFunction covert)
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