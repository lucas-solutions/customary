using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Raven.Json.Linq;

    public abstract class Metadata
    {
        protected readonly RavenJObject _data;

        protected Metadata(RavenJObject data)
        {
            _data = data;
        }

        protected RavenJToken SingleOrDefault<T>(string collection, string property, T value)
        {
            var array = _data.Value<RavenJArray>(collection);
            return array != null ? array.SingleOrDefault(o => value.Equals(o.Value<T>(property))) : null;
        }

        protected RavenJArray Array(string name)
        {
            return _data[name] as RavenJArray;
        }

        protected static T Value<T>(params T[] values)
            where T : class
        {
            return values.Where(o => o != null).FirstOrDefault();
        }

        #region - mvc -

        public virtual string MvcRouteName
        {
            get { return null; }
        }

        public virtual string MvcAreaName
        {
            get { return null; }
        }

        public virtual string MvcControllerName
        {
            get { return this.GetType().Name; }
        }

        #endregion - mvc -

        public static void Merge(RavenJObject importJObject)
        {
        }
    }

    public abstract class Metadata<TEntity> : Metadata
        where TEntity : class
    {
        protected Metadata(RavenJObject data)
            : base(data)
        {
        }
    }
}