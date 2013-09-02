using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    using Custom.Models;

    public class EvernoteNoteRepository : INoteRepository, IRepository<Note>, IQueryable<Note>, IEnumerable<Note>, IDisposable
    {
        public void Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Note entity)
        {
            throw new NotImplementedException();
        }

        public Note Get(Note entity)
        {
            throw new NotImplementedException();
        }

        public void IgnoreChanges()
        {
            throw new NotImplementedException();
        }

        public Note Save(Note entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Store(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }

        #region - IDisposable implementation -

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion - IDisposable implementation -

        #region - IEnumerable<Note> -

        IEnumerator<Note> IEnumerable<Note>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable<Note> -

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
