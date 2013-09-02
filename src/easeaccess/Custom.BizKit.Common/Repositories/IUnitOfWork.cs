using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    /// <summary>
    /// Unit Of Work Pattern
    /// http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUnitOfWork<TEntity>
        where TEntity : class, new()
    {
        void MarkDirty(TEntity entity);

        void MarkNew(TEntity entity);

        void MarkDeleted(TEntity entity);

        void Commit();

        void Rollback();
    }
}
