using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.grid
{
    partial class Panel
    {
        private Serializer _serializer;

        public Serializer ToSerializer()
        {
            return _serializer ?? (_serializer = new Serializer(this));
        }

        public sealed class Serializer : Serializer<Ext.grid.Panel, Ext.grid.Panel.Serializer>
        {
            public Serializer()
                : this(new Ext.grid.Panel())
            {
            }

            public Serializer(Ext.grid.Panel model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Ext.panel.Table.Serializer<TModel, TSerializer>
            where TModel : Panel
            where TSerializer : Panel.Serializer<TModel, TSerializer>
        {
            protected Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}