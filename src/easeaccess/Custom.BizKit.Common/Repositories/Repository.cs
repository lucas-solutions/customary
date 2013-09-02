using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly Dictionary<string, TEntity> _dictionary;
        private readonly Func<object, string> _idGetter;

        public Repository()
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

            _dictionary = new Dictionary<string, TEntity>();
        }

        public TEntity Get(TEntity entity)
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

            _dictionary.TryGetValue(id, out entity);

            return entity;
        }

        public void Add(TEntity entity)
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

            if (_dictionary.ContainsKey(id))
            {
                throw new InvalidOperationException("entity already exists.");
            }

            _dictionary.Add(id, entity);
        }

        public void Delete(TEntity entity)
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

            if (_dictionary.ContainsKey(id))
            {
                throw new InvalidOperationException("entity doesn't exists.");
            }

            _dictionary.Remove(id);
        }

        public void Update(TEntity entity)
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

            if (!_dictionary.ContainsKey(id))
            {
                throw new InvalidOperationException("entity doesn't exists.");
            }

            _dictionary[id] = entity;
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

            if (_dictionary.ContainsKey(id))
            {
                throw new InvalidOperationException("entity already exists.");
            }

            if (_dictionary.ContainsKey(id))
            {
                _dictionary[id] = entity;
            }
            else
            {
                _dictionary.Add(id, entity);
            }
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
            get { return _dictionary.Values.AsQueryable().ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _dictionary.Values.AsQueryable().Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _dictionary.Values.AsQueryable().Provider; }
        }

        #endregion - IQueryable implementation -

        #region - IEnumerable<TEntity> implementation -

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _dictionary.Values.GetEnumerator();
        }

        #endregion - IEnumerable<TEntity> implementation -

        #region - IEnumerable implementation -

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.Values.GetEnumerator();
        }

        #endregion - IEnumerable implementation -

        #region - IDisposable implementation -

        void IDisposable.Dispose()
        {
        }

        #endregion - IDisposable implementation -
    }
}
