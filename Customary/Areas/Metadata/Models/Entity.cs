using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Metadata;
    using Custom.Presentation;
    using Ext = Custom.Presentation.Sencha.Ext;

    public sealed class Entity
    {
        public static implicit operator Entity(EntityDescriptor descriptor)
        {
            return new Entity(descriptor);
        }

        public static implicit operator EntityDescriptor(Entity entity)
        {
            return entity.Descriptor;
        }

        public static implicit operator Ext.form.Panel(Entity entity)
        {
            return entity.Form;
        }

        public static implicit operator Ext.grid.Panel(Entity entity)
        {
            return entity.Grid;
        }

        public static implicit operator Ext.data.Model(Entity entity)
        {
            return entity.Model;
        }

        public static implicit operator Ext.data.proxy.Proxy(Entity entity)
        {
            return entity.Proxy;
        }

        public static implicit operator Ext.data.Store(Entity entity)
        {
            return entity.Store;
        }

        public static implicit operator Raven.Json.Linq.RavenJObject(Entity entity)
        {
            return entity.JObject;
        }

        private readonly EntityDescriptor _descriptor;
        private Ext.form.Panel _form;
        private Ext.grid.Panel _grid;
        private Ext.data.Model _model;
        private Ext.data.proxy.Proxy _proxy;
        private Ext.data.Store _store;
        private Raven.Json.Linq.RavenJObject _jo;

        public Entity()
            : this(new EntityDescriptor())
        {
            var data = new Newtonsoft.Json.Linq.JObject();
        }

        public Entity(EntityDescriptor descriptor)
        {
            _descriptor = descriptor ?? new EntityDescriptor();
        }

        public EntityDescriptor Descriptor
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

        public Raven.Json.Linq.RavenJObject JObject
        {
            get { return _jo ?? (_jo = _descriptor.ToJObject()); }
        }

        public enum Handlers
        {
            OnClick,

            OnMouseMove,

            OnMouseUp,
        }
    }
}