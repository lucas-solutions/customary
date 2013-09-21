using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Ext = Custom.Presentation.Sencha.Ext;
    using Custom.Metadata;
    using Custom.Presentation;

    public class Entity
    {
        public static implicit operator Ext.data.Model(Entity entity)
        {
            return entity._model;
        }

        private Ext.grid.Panel _grid;
        private Ext.data.Model _model;
        private Ext.panel.Panel _panel;
        private Ext.data.proxy.Proxy _proxy;
        private Ext.data.Store _store;

        public EntityDescriptor Descriptor
        {
            get;
            set;
        }

        public Ext.grid.Panel Panel
        {
            get;
            set;
        }

        public enum Handlers
        {
            OnClick,

            OnMouseMove,

            OnMouseUp,
        }
    }
}