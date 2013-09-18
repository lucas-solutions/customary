using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.proxy
{
    public partial class Proxy : Base
    {
        private Builder _builder;
        private ScriptField<Ext.data.reader.Reader> _reader;
        private ScriptField<Ext.data.writer.Writer> _writer;

        /// <summary>
        /// True to batch actions of a particular type when synchronizing the store.
        /// </summary>
        public bool BatchActions
        {
            get;
            set;
        }

        /// <summary>
        /// Comma-separated ordering 'create', 'update' and 'destroy' actions when batching.
        /// </summary>
        public string BatchOrder
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the Model to tie to this Proxy.
        /// </summary>
        public string Model
        {
            get;
            set;
        }

        /// <summary>
        /// The Ext.data.reader.Reader to use to decode the server's response or data read from client.
        /// </summary>
        public ScriptField<Ext.data.reader.Reader> Reader
        {
            get { return _reader ?? (_reader = new ScriptField<Ext.data.reader.Reader>()); }
            set { (_reader ?? (_reader = new ScriptField<Ext.data.reader.Reader>())).Assign(value); }
        }

        public string Type
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// The Ext.data.writer.Writer to use to encode any request sent to the server or saved to client.
        /// </summary>
        public ScriptField<Ext.data.writer.Writer> Writer
        {
            get { return _writer ?? (_writer = new ScriptField<Ext.data.writer.Writer>()); }
            set { (_writer ?? (_writer = new ScriptField<Ext.data.writer.Writer>())).Assign(value); }
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }
    }
}