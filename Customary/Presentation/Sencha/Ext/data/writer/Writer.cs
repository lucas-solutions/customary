using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.writer
{
    public abstract class Writer : Base
    {
        public new abstract class Builder<TScript, TBuilder> : Base.Builder<TScript, TBuilder>
            where TScript : Writer
            where TBuilder : Writer.Builder<TScript, TBuilder>
        {
            public Builder(TScript model)
                : base(model)
            {
            }
        }
    }
}