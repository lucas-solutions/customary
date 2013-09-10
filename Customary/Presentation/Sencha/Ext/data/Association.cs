using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class Association
    {
        public string Model
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public AssociationTypes Type
        {
            get;
            set;
        }

        public void WriteTo(ScriptWriter writer)
        {
        }
    }
}