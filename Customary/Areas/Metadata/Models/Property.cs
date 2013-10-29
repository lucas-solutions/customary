using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Data.Metadata;
    using Custom.Site.Presentation;
    using Ext = Custom.Site.Presentation.Sencha.Ext;

    public class Property
    {
        public static implicit operator Property(PropertyDefinition descriptor)
        {
            return new Property(descriptor);
        }

        public static implicit operator PropertyDefinition(Property property)
        {
            return property.Descriptor;
        }

        public static implicit operator Ext.form.Panel(Property property)
        {
            return property.Form;
        }

        public static implicit operator Ext.grid.Panel(Property property)
        {
            return property.Grid;
        }

        public static implicit operator Ext.data.Model(Property property)
        {
            return property.Model;
        }

        public static implicit operator Ext.data.proxy.Proxy(Property property)
        {
            return property.Proxy;
        }

        public static implicit operator Ext.data.Store(Property property)
        {
            return property.Store;
        }

        private readonly PropertyDefinition _descriptor;
        private Ext.form.Panel _form;
        private Ext.grid.Panel _grid;
        private Ext.data.Model _model;
        private Ext.data.proxy.Proxy _proxy;
        private Ext.data.Store _store;

        public Property()
            : this(new PropertyDefinition())
        {
        }

        public Property(PropertyDefinition descriptor)
        {
            _descriptor = descriptor ?? new PropertyDefinition();
        }

        public PropertyDefinition Descriptor
        {
            get { return _descriptor; }
        }

        public Ext.form.Panel Form
        {
            get { return _form ?? (_form = _descriptor.ToForm()); }
        }

        public Ext.grid.Panel Grid
        {
            get { return _grid ?? (_grid = _descriptor.ToGrid()); }
        }

        public Ext.data.Model Model
        {
            get { return _model ?? (_model = _descriptor.ToModel()); }
        }

        public Ext.data.proxy.Proxy Proxy
        {
            get { return _proxy ?? (_proxy = _descriptor.ToProxy()); }
        }

        public Ext.data.Store Store
        {
            get { return _store ?? (_store = _descriptor.ToStore()); }
        }

        public enum Handlers
        {
            OnClick,

            OnMouseMove,

            OnMouseUp,
        }
    }
}