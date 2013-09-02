using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    public class DictionaryRepository<TKey, TValue> : IRepository<TKey, TValue>
    {
        public static implicit operator DictionaryRepository<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            return new DictionaryRepository<TKey,TValue>(dictionary);
        }

        public static implicit operator Dictionary<TKey, TValue>(DictionaryRepository<TKey, TValue> repository)
        {
            return repository != null ? repository._dictionary : null;
        }

        private readonly Dictionary<TKey, TValue> _dictionary;

        public DictionaryRepository()
        {
            _dictionary = new Dictionary<TKey,TValue>();
        }

        public DictionaryRepository(Dictionary<TKey, TValue> dictionary)
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
                TValue value;
                _dictionary.TryGetValue(key, out value);
                return value;
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Remove(TKey key, out TValue value)
        {
            if (!_dictionary.TryGetValue(key, out value))
                return false;

            _dictionary.Remove(key);
            return true;
        }

        public bool Update(TKey key, TValue newValue)
        {
            _dictionary[key] = newValue;
            return true;
        }

        #endregion - IRepository<TKey, TValue> implementation -
    }
}
