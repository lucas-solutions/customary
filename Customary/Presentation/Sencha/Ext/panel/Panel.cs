using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.panel
{
    public class Panel : Ext.panel.AbstractPanel
    {
        private Builder _builder;
        private Serializer _serializer;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder());
        }

        protected override IScriptSerializer ToNativeSerializer()
        {
            return ToSerializer();
        }

        public Serializer ToSerializer()
        {
            return _serializer ?? (_serializer = new Serializer(this));
        }

        public class Builder : Panel.Builder<Panel, Panel.Builder>
        {
            public Builder()
                : base(new Panel())
            {
            }

            public Builder(Panel model)
                : base(model)
            {
            }

            public static implicit operator Panel.Builder(Panel model)
            {
                return model.ToBuilder();
            }
        }

        public new class Builder<TModel, TBuilder> : Ext.panel.AbstractPanel.Builder<TModel, TBuilder>
            where TModel : Panel
            where TBuilder : Panel.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }

        public class Serializer : Panel.Serializer<Panel, Panel.Serializer>
        {
            public Serializer(Panel model)
                : base(model)
            {
            }
        }

        public new class Serializer<TModel, TSerializer> : Ext.panel.AbstractPanel.Serializer<TModel, TSerializer>
            where TModel : Panel
            where TSerializer : Panel.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }

            protected override void Serialize(TModel model, ScriptWriter writer)
            {
            }
        }
    }
}