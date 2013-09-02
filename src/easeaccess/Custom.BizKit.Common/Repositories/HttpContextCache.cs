using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Custom.Persistence
{
    public class HttpContextCache<TValue> : IRepository<string, TValue>
        where TValue : class
    {
        #region - IRepository<string, TValue> -

        public int Count
        {
            get { return HttpContext.Current.Cache.Count; }
        }

        public TValue this[string key]
        {
            get { return HttpContext.Current.Cache[key] as TValue; }
            set { HttpContext.Current.Cache[key] = value; }
        }

        public void Add(string key, TValue value)
        {
            HttpContext.Current.Cache.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key, out TValue value)
        {
            var item = HttpContext.Current.Cache.Remove(key);
            value = item as TValue;
            return item != null;
        }

        public bool Update(string key, TValue newValue)
        {
            HttpContext.Current.Cache[key] = newValue;
            return true;
        }

        #endregion - IRepository<string, TValue> -
    }
}
