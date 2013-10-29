using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data.proxy
{
    partial class Proxy
    {
        public class Builder : Proxy.Builder<Proxy, Proxy.Builder>
        {
            public Builder()
                : base(new Proxy())
            {
            }

            public Builder(Proxy model)
                : base(model)
            {
            }

            public static implicit operator Proxy.Builder(Proxy model)
            {
                return model.ToBuilder();
            }
        }

        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : Proxy
            where TBuilder : Proxy.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }

            /// <summary>
            /// True to batch actions of a particular type when synchronizing the store.
            /// </summary>
            public TBuilder BatchActions(bool value)
            {
                ToModel().BatchActions = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// Comma-separated ordering 'create', 'update' and 'destroy' actions when batching.
            /// </summary>
            public TBuilder BatchOrder(string value)
            {
                ToModel().BatchOrder = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The name of the Model to tie to this Proxy.
            /// </summary>
            public TBuilder Model(string value)
            {
                ToModel().Model = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The Ext.data.reader.Relader to use to decode the server's response or data read from client.
            /// </summary>
            public TBuilder Reader(ScriptField<Ext.data.reader.Reader> value)
            {
                ToModel().Reader = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The Ext.data.writer.Writer to use to encode any request sent to the server or saved to client.
            /// </summary>
            public TBuilder Writer(ScriptField<Ext.data.writer.Writer> value)
            {
                ToModel().Writer = value;
                return (TBuilder)this;
            }
        }
    }
}