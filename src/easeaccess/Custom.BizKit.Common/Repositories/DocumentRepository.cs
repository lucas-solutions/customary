using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    using Raven.Client;

    public class DocumentRepository<TEntity> : IRepository<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IDisposable
        where TEntity : class, new()
    {
        private IDocumentSession _session;
        private readonly Func<object, string> _idGetter;

        public DocumentRepository()
        {
            var type = typeof(TEntity);
            var idProp = type.GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);

            if (idProp == null)
            {
                throw new TypeInitializationException(GetType().FullName, new Exception("Id property expected on type " + typeof(TEntity).AssemblyQualifiedName));
            }

            if (typeof(string) != idProp.PropertyType)
            {
                throw new TypeInitializationException(GetType().FullName, new Exception("Id property must be of string type on type " + typeof(TEntity).AssemblyQualifiedName));
            }

            var idGetter = idProp.GetGetMethod();

            if (idGetter == null)
            {
                throw new TypeInitializationException(GetType().FullName, new Exception("Id property getter expected on type " + typeof(TEntity).AssemblyQualifiedName));
            }

            //
            // The suggestion to use an expression tree to construct a lambda using the given MethodInfo, 
            // in conjunction with the Expression<TDelegate>.Compile method.

            var instance = Expression.Parameter(typeof(object), "instance");

            _idGetter = Expression.Lambda<Func<object, string>>(Expression.Call(Expression.Convert(instance, type), idGetter), instance).Compile();
        }

        private IDocumentSession Session
        {
            get { return _session ?? (_session = Documents.DocumentStoreHolder.Store.OpenSession()); }
        }

        public TEntity Get(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            //Session.Advanced.Refresh(entity);

            var id = _idGetter(entity);

            if (id == null)
            {
                throw new ArgumentException("Id is null");
            }

            entity = Session.Load<TEntity>(id);

            return entity;
        }

        public void Add(TEntity entity)
        {
            Store(entity);
        }

        public void Delete(TEntity entity)
        {
            var metadata = Session.Advanced.GetMetadataFor<TEntity>(entity);

            if (metadata == null)
            {
                entity = Get(entity);
            }

            Session.Delete<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            Store(entity);
        }

        public void Store(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            var id = _idGetter(entity);

            if (id == null)
            {
                throw new ArgumentException("Id is null");
            }

            Session.Store(entity, id);
        }

        public TEntity Save(TEntity entity)
        {
            Store(entity);

            SaveChanges();

            return Get(entity);
        }

        public void IgnoreChanges()
        {
            // reset session. make session recreated
            _session = null;
        }

        public void SaveChanges()
        {
            var session = _session;

            if (session != null)
            {
                session.SaveChanges();
            }
        }

        public string IdFor(TEntity entity)
        {
            return Session.Advanced.GetDocumentId(entity);
        }

        public string UrlFor(TEntity entity)
        {
            return Session.Advanced.GetDocumentUrl(entity);
        }

        #region - IDisposable implementation -

        void IDisposable.Dispose()
        {
            SaveChanges();
        }

        #endregion - IDisposable implementation -

        #region - IEnumerable<TEntity> -

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return Session.Query<TEntity>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _session.Query<TEntity>().GetEnumerator();
        }

        #endregion - IEnumerable<TEntity> -

        #region - IQueryable<TEntity> implementation -

        Type IQueryable.ElementType
        {
            get { return Session.Query<TEntity>().ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return Session.Query<TEntity>().Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return Session.Query<TEntity>().Provider; }
        }

        #endregion - IQueryable<TEntity> implementation -
    }
}
