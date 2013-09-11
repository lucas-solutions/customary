using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.form
{
    [Ext(Name = "Ext.form.FieldSet", XType = "fieldset")]
    public class FieldSet : Ext.container.Container
    {
        protected override IScriptSerializer ToNativeSerializer()
        {
            throw new NotImplementedException();
        }
    }
}