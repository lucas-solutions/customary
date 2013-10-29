using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data.reader
{
    public abstract class Reader : Base
    {
        public string IdProperty
        {
            get;
            set;
        }

        public bool ImplicitIncludes
        {
            get;
            set;
        }

        public new abstract class Builder<TScript, TBuilder> : Base.Builder<TScript, TBuilder>
            where TScript : Reader
            where TBuilder : Reader.Builder<TScript, TBuilder>
        {
            public Builder(TScript scrcipt)
                : base(scrcipt)
            {
            }
        }
    }
}