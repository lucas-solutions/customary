using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.container
{
    partial class Viewport
    {
        protected override IScriptSerializer ToNativeSerializer()
        {
            return new Serializer(this);
        }

        public class Serializer : Serializer<Viewport, Serializer>
        {
            public Serializer(Viewport model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Ext.container.Container.Serializer<TModel, TSerializer>
            where TModel : Viewport
            where TSerializer : Viewport.Serializer<TModel, TSerializer>
        {
            protected Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}