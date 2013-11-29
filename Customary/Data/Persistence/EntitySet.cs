using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    /// <summary>
    /// Repository model
    /// </summary>
    public interface IEntitySet
    {
    }

    /// <summary>
    /// Repository model
    /// </summary>
    public interface IEntitySet<T>
        where T : class
    {
        IEnumerable<T> Load();

        T Load(Guid id);

        T Load(NameValueCollection query);

        void Save(T entity);

        void Save(IEnumerable<T> collection);
    }

    /// <summary>
    /// Repository model
    /// </summary>
    public class EntitySet : IEntitySet
    {
    }

    public class EntitySet<T> : EntitySet, IEntitySet<T>
        where T : class
    {
        public IEnumerable<T> Load()
        {
            throw new NotImplementedException();
        }

        public T Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Load(NameValueCollection query)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}