using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Custom.Web
{
    using Custom.Data.Serialization;

    public class DataRequestVerb
    {
        /// <summary>
        /// Area children
        /// </summary>
        public static readonly DataRequestVerb Children = new DataRequestVerb("Children", "GET");

        /// <summary>
        /// Returns entity minimum info
        /// </summary>
        public static readonly DataRequestVerb Head = new DataRequestVerb("Head", "GET");

        /// <summary>
        /// Returns entity complete info
        /// </summary>
        public static readonly DataRequestVerb Read = new DataRequestVerb("Read", "GET");

        /// <summary>
        /// Creaate new entity
        /// </summary>
        public static readonly DataRequestVerb Create = new DataRequestVerb("Create", "POST|PUT");

        /// <summary>
        /// Delete existing entity
        /// </summary>
        public static readonly DataRequestVerb Delete = new DataRequestVerb("Delete", "GET");

        /// <summary>
        /// Update existing entity
        /// </summary>
        public static readonly DataRequestVerb Update = new DataRequestVerb("Update", "PATCH|POST");

        /// <summary>
        /// Invoke service
        /// </summary>
        public static readonly DataRequestVerb Invoke = new DataRequestVerb("Invoke", "POST");

        /// <summary>
        /// New entity dropplet
        /// </summary>
        public static readonly DataRequestVerb New = new DataRequestVerb("New", "GET");

        /// <summary>
        /// Edit entity droppet
        /// </summary>
        public static readonly DataRequestVerb Edit = new DataRequestVerb("Edit", "GET");

        /// <summary>
        /// View entity dropplet (readonly)
        /// </summary>
        public static readonly DataRequestVerb View = new DataRequestVerb("View", "GET");

        /// <summary>
        /// Dropplet for service
        /// </summary>
        public static readonly DataRequestVerb Drop = new DataRequestVerb("Drop", "GET");

        /// <summary>
        /// Preflight response
        /// </summary>
        public static readonly DataRequestVerb Options = new DataRequestVerb("Options");

        /// <summary>
        /// Full blown data explorer
        /// </summary>
        public static readonly DataRequestVerb Browse = new DataRequestVerb("Browse", "GET");

        //public static readonly DataRequestVerb Directory = new DataRequestVerb("Directory");

        public static readonly DataRequestVerb[] _all;

        static DataRequestVerb()
        {
            _all = typeof(DataRequestVerb).GetFields(BindingFlags.Public | BindingFlags.Static).Select(o => o.GetValue(null) as DataRequestVerb).ToArray();
        }

        public static implicit operator string(DataRequestVerb verb)
        {
            return verb != null ? verb._name : null;
        }

        public static bool operator ==(DataRequestVerb left, DataRequestVerb right)
        {
            if (object.Equals(left, null))
                return object.Equals(right, null);

            if (object.Equals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(DataRequestVerb left, DataRequestVerb right)
        {
            return !(left == right);
        }

        private string _name;
        private string[] _methods;
        private StreamFormat[] _formats;

        public DataRequestVerb(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Argument Empty String", "name");

            _name = name;
        }

        public DataRequestVerb(string name, string method)
            : this(name)
        {
            if (!string.IsNullOrEmpty(method))
                _methods = method.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(o => o.ToUpperInvariant()).ToArray();
        }

        public DataRequestVerb(string name, params StreamFormat[] formats)
            : this(name)
        {
            _formats = formats;
        }

        public DataRequestVerb(string name, string method, params StreamFormat[] formats)
            : this(name, method)
        {
            _formats = formats;
        }

        public bool Accepts(string method)
        {
            return _methods != null ? _methods.Any(o => string.Equals(o, method, StringComparison.OrdinalIgnoreCase)) : true;
        }

        public bool Accepts(StreamFormat format)
        {
            return _formats != null ? _formats.Any(o => o.Equals(format)) : true;
        }

        public bool Equals(DataRequestVerb other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this._name, other._name))
                return true;

            if (string.Compare(this._name, other._name, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DataRequestVerb);
        }

        public override int GetHashCode()
        {
            return this._name.ToUpperInvariant().GetHashCode();
        }

        public override string ToString()
        {
            return this._name.ToString();
        }

        public bool Valid
        {
            get { return _all.Any(o => o == _name); }
        }
    }
}