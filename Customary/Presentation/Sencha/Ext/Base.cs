using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Custom.Presentation.Sencha.Ext
{
    [Description("Abstract base class that provides a common interface for publishing events")]
    public abstract class Base : ScriptObject
    {   
        protected Base()
        {
        }

        public new abstract class Builder<TModel, TBuilder> : ScriptObject.Builder<TModel, TBuilder>
            where TModel : Base
            where TBuilder : Base.Builder<TModel, TBuilder>
        {
            protected Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}