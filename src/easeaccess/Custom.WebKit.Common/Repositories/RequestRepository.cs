using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    public class RequestRepository<TEntity> : IRepository<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable, IDisposable
        where TEntity : class, new()
    {
        public TEntity Get(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Store(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void IgnoreChanges()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        #region - IQueryable implementation -

        Type IQueryable.ElementType
        {
            get { throw new NotImplementedException(); }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { throw new NotImplementedException(); }
        }

        IQueryProvider IQueryable.Provider
        {
            get { throw new NotImplementedException(); }
        }

        #endregion - IQueryable implementation -

        #region - IEnumerable<TEntity> implementation -

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable<TEntity> implementation -

        #region - IEnumerable implementation -

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable implementation -

        #region - IDisposable implementation -

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion - IDisposable implementation -
    }
}
