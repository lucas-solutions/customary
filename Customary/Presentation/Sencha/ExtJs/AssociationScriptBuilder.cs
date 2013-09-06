using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.ExtJs
{
    using Custom.Metadata;

    public class AssociationScriptBuilder : ScriptBuilder
    {
        private string _hasMany;
        private string _belongsTo;

        public AssociationScriptBuilder()
        {
        }

        public AssociationScriptBuilder(PropertyDescriptor property)
        {
        }

        public AssociationScriptBuilder HasMany(string hasMany)
        {
            _hasMany = hasMany;
            return this;
        }

        public AssociationScriptBuilder BelongsTo(string belongsTo)
        {
            _belongsTo = belongsTo;
            return this;
        }

        public override void Write(TextWriter writer)
        {
            writer.Write("{ hasMany: '" + _hasMany + "', belongsTo: '" + _belongsTo + "' }");
        }
    }
}