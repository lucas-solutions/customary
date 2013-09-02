using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    public class ConcurrentDictionaryRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        public static implicit operator ConcurrentDictionaryRepository<TKey, TValue>(ConcurrentDictionary<TKey, TValue> dictionary)
        {
            return new ConcurrentDictionaryRepository<TKey,TValue>(dictionary);
        }

        public static implicit operator ConcurrentDictionary<TKey, TValue>(ConcurrentDictionaryRepository<TKey, TValue> repository)
        {
            return repository != null ? repository._dictionary : null;
        }

        private readonly ConcurrentDictionary<TKey, TValue> _dictionary;

        public ConcurrentDictionaryRepository()
        {
            _dictionary = new ConcurrentDictionary<TKey,TValue>();
        }

        public ConcurrentDictionaryRepository(ConcurrentDictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary;
        }

        #region - IRepository<TKey, TValue> implementation -

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public bool Update(TKey key, TValue newValue)
        {
            throw new NotImplementedException();
        }

        #endregion - IRepository<TKey, TValue> implementation -
    }
}
