using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Data.Metadata;
    using Custom.Site.Presentation;
    using Ext = Custom.Site.Presentation.Sencha.Ext;

    public class Member
    {
        public static implicit operator Member(DefinitionBase descriptor)
        {
            return new Member(descriptor);
        }

        public static implicit operator DefinitionBase(Member member)
        {
            return member.Descriptor;
        }

        public static implicit operator Ext.form.Panel(Member member)
        {
            return member.Form;
        }

        public static implicit operator Ext.grid.Panel(Member member)
        {
            return member.Grid;
        }

        public static implicit operator Ext.data.Model(Member member)
        {
            return member.Model;
        }

        public static implicit operator Ext.data.proxy.Proxy(Member member)
        {
            return member.Proxy;
        }

        public static implicit operator Ext.data.Store(Member member)
        {
            return member.Store;
        }

        private readonly DefinitionBase _descriptor;
        private Ext.form.Panel _form;
        private Ext.grid.Panel _grid;
        private Ext.data.Model _model;
        private Ext.data.proxy.Proxy _proxy;
        private Ext.data.Store _store;

        public Member()
            : this(new DefinitionBase())
        {
        }

        public Member(DefinitionBase descriptor)
        {
            _descriptor = descriptor ?? new DefinitionBase();
        }

        public DefinitionBase Descriptor
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