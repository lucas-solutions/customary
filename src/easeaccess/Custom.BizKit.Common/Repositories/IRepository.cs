using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    /// <summary>
    /// Repository for storing and querying entities.
    /// Implementation should call SaveChages on Dispose;
    /// </summary>
    /// <typeparam name="TEntity">Entity object class.</typeparam>
    public interface IRepository<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IDisposable
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets the stored entity object with matching entity key for the supplied entity.
        /// </summary>
        /// <param name="entity">Entity to match.</param>
        /// <returns>The entity object</returns>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid value for one or more entity keys.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        TEntity Get(TEntity entity);

        /// <summary>
        /// Add if doesn't exits. If exists throws an exception at SaveChanges
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid or missing value for one or more properties.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        void Add(TEntity entity);

        /// <summary>
        /// Delete an entity object.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid or missing value for one or more properties.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        void Delete(TEntity entity);

        /// <summary>
        /// Updates the entity. If doesnt exists throws an exception at SaveChanges.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid or missing value for one or more properties.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        void Update(TEntity entity);

        /// <summary>
        /// Add or update. 
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid or missing value for one or more properties.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        void Store(TEntity entity);

        /// <summary>
        /// Save and return the current state of the object.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <returns>The updated entity object.</returns>
        /// <exception cref="ArgumentNullException">The entity parameter is null.</exception>
        /// <exception cref="ArgumentException">The entity had an invalid or missing value for one or more properties.</exception>
        /// <exception cref="RepositiryException">One or more conflicts found while saving.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        TEntity Save(TEntity entity);
    }
}
