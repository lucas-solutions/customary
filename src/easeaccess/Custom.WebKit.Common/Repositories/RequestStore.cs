using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custom.Repositories
{
    public class RequestStore
    {
        private static readonly object _lock = new object();
        private static RequestStore _instance;

        public static RequestStore Instance
        {
            get
            {
                var instance = _instance;

                // return without locking if already exist
                if (instance != null)
                    return instance;

                // lock and check again
                lock (_lock)
                {
                    // create new instance if doesn't exist
                    instance = _instance ?? (_instance = new RequestStore()
                    {
                    });
                }

                return instance;
            }
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, new()
        {
            IRepository<TEntity> repo;
            var type = typeof(IRepository<TEntity>);
            var key = type.FullName;
            var value = HttpContext.Current.Items[key];

            if (value == null)
            {
                repo = new Repository<TEntity>();
                HttpContext.Current.Items[key] = repo;
            }
            else if (value is IRepository<TEntity>)
            {
                repo = value as IRepository<TEntity>;
            }
            else
            {
                throw new InvalidCastException(string.Format("The existing object for this key is of type {0}", value.GetType()));
            }

            return repo;
        }
    }
}
