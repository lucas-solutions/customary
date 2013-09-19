using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.util
{
    public class Observable : ScriptObject
    {
        private Builder _builder;
        private ListenerCollection _listeners;

        /// <summary>
        /// A config object containing one or more event handlers to be added to this object during initialization. This should be a valid listeners config object as specified in the addListener example for attaching multiple handlers at once.
        /// </summary>
        public ListenerCollection Listeners
        {
            get { return _listeners ?? (_listeners = new ListenerCollection()); }
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        protected override Scriptable ToScriptable()
        {
            return ToBuilder();
        }

        public class Builder : Builder<Observable, Builder>
        {
            public Builder(Observable model)
                : base(model)
            {
            }
        }

        public new abstract class Builder<TModel, TBuilder> : ScriptObject.Builder<TModel, TBuilder>
            where TModel : ScriptObject
            where TBuilder : Builder<TModel, TBuilder>
        {
            protected Builder(TModel model)
                : base(model)
            {
            }

            public TBuilder Listeners(Action<ListenerCollection> action)
            {
                return (TBuilder)this;
            }
        }

        public class ListenerCollection
        {
        }
    }
}