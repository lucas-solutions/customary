using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Metadata;
    using Custom.Presentation;
    using Ext = Custom.Presentation.Sencha.Ext;

    public static class MemberExtensions
    {
        public static Ext.form.Panel ToForm(this Descriptor descriptor)
        {
            var builder = new Ext.form.Panel.Builder();

            return builder;
        }

        public static Ext.grid.Panel ToGrid(this Descriptor descriptor)
        {
            var builder = new Ext.grid.Panel.Builder();

            return builder;
        }

        public static Ext.data.Model ToModel(this Descriptor descriptor)
        {
            var builder = new Ext.data.Model.Builder();

            return builder;
        }

        public static Ext.data.proxy.Proxy ToProxy(this Descriptor descriptor)
        {
            var builder = new Ext.data.proxy.Proxy.Builder();

            return builder;
        }

        public static Ext.data.Store ToStore(this Descriptor descriptor)
        {
            var builder = new Ext.data.Store.Builder();

            return builder;
        }
    }
}