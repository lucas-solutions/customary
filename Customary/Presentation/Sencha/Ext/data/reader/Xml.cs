using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.reader
{
    public abstract class Xml : Reader
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder : Builder<Xml, Builder>
        {
            public Builder(Xml model)
                : base(model)
            {
            }
        }
    }
}