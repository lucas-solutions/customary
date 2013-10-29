using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Data.Metadata;
    using Custom.Site.Presentation;
    using Ext = Custom.Site.Presentation.Sencha.Ext;

    public class Enum
    {
        public static implicit operator Enum(EnumDefinition descriptor)
        {
            return new Enum(descriptor);
        }

        public static implicit operator EnumDefinition(Enum enumerable)
        {
            return enumerable.Descriptor;
        }

        public static implicit operator Ext.form.Panel(Enum enumerable)
        {
            return enumerable.Form;
        }

        public static implicit operator Ext.grid.Panel(Enum enumerable)
        {
            return enumerable.Grid;
        }

        public static implicit operator Ext.data.Model(Enum enumerable)
        {
            return enumerable.Model;
        }

        public static implicit operator Ext.data.proxy.Proxy(Enum enumerable)
        {
            return enumerable.Proxy;
        }

        public static implicit operator Ext.data.Store(Enum enumerable)
        {
            return enumerable.Store;
        }

        private readonly EnumDefinition _descriptor;
        private Ext.form.Panel _form;
        private Ext.grid.Panel _grid;
        private Ext.data.Model _model;
        private Ext.data.proxy.Proxy _proxy;
        private Ext.data.Store _store;

        public Enum()
            : this(new EnumDefinition())
        {
        }

        public Enum(EnumDefinition descriptor)
        {
            _descriptor = descriptor ?? new EnumDefinition();
        }

        public EnumDefinition Descriptor
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