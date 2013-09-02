using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Persistence
{
    using Enyim.Caching;
    using Enyim.Caching.Memcached;

    public class MemcachedRepository<TValue> : IRepository<string, TValue>
        where TValue : class
    {
        private readonly MemcachedClient _client;

        public MemcachedRepository()
        {
            _client = new MemcachedClient();
        }

        #region - IRepository<string, TValue> implementation -

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public TValue this[string key]
        {
            get { return _client.Get<TValue>(key); }
            set { _client.Store(StoreMode.Set, key, value); }
        }

        public void Add(string key, TValue value)
        {
            _client.Store(StoreMode.Add, key, value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key, out TValue value)
        {
            var item = _client.Get(key);
            value = item as TValue;
            if (value != null)
            {
                return _client.Remove(key);
            }
            return false;
        }

        public bool Update(string key, TValue newValue)
        {
            return _client.Store(StoreMode.Replace, key, newValue);
        }

        #endregion - IRepository<string, TValue> implementation -
    }
}
