using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    using Custom.Models;

    public class DropboxFileRepository : IFileRepository, IRepository<File>, IQueryable<File>, IEnumerable<File>, IDisposable
    {
        public void Add(File entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(File entity)
        {
            throw new NotImplementedException();
        }

        public File Get(File entity)
        {
            throw new NotImplementedException();
        }

        public void IgnoreChanges()
        {
            throw new NotImplementedException();
        }

        public File Save(File entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Store(File entity)
        {
            throw new NotImplementedException();
        }

        public void Update(File entity)
        {
            throw new NotImplementedException();
        }

        #region - IDisposable implementation -

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion - IDisposable implementation -

        #region - IEnumerable<TEntity> -

        IEnumerator<File> IEnumerable<File>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable<TEntity> -

        #region - IQueryable implementation -

        Type IQueryable.ElementType
        {
            get { throw new NotImplementedException(); }
        }

        Expression IQueryable.Expression
        {
            get { throw new NotImplementedException(); }
        }

        IQueryProvider IQueryable.Provider
        {
            get { throw new NotImplementedException(); }
        }

        #endregion - IQueryable implementation -
    }
}
