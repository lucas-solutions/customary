using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class AssociationCollection : ScriptArray<AssociationCollection, Association>
    {
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