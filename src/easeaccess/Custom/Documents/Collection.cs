using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public class Collection<TValue> : IList<TValue>
        where TValue : Component
    {
        private readonly object _context;
        private readonly string _key;
        private readonly RavenJArray _array;
        private readonly Dictionary<string, TValue> _values;

        public Collection(string key, RavenJArray array, object context)
        {
            _key = key;
            _array = array;
            _context = context;
            _values = new Dictionary<string, TValue>(array.Length);
        }

        public int IndexOf(TValue item)
        {
            return _array.IndexOf(item, (x, y) => { return string.Compare(x.Value<string>(_key), y.Value<string>(_key)); });
        }

        public void Insert(int index, TValue item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            _array.RemoveAt(index);
        }

        public TValue this[int index]
        {
            get
            {
                var item = _array[index];
                var key = item.Value<string>(_key);

                TValue value;
                if (_values.TryGetValue(_key, out value))
                    return value;

                value = (TValue)Activator.CreateInstance(typeof(TValue), new object[] { item, _context });

                _values.Add(key, value);

                return value;
            }
            set
            {
                _array[index] = value;
            }
        }

        public TValue this[string key]
        {
            get
            {
                TValue value;
                if (_values.TryGetValue(key, out value))
                    return value;
                
                for (var index = 0; index < _array.Length; index++)
                {
                    var item = _array[index];
                    if (0 == string.Compare(key, item.Value<string>(_key)))
                    {
                        value = (TValue)Activator.CreateInstance(typeof(TValue), new object[] { item, _context });

                        _values.Add(key, value);
                    }
                }
                return value;
            }
            set
            {
                _values[key] = value;

                var index = IndexOf(value);

                if (index < 0)
                    _array.Add(value);
                else
                    _array[index] = value;
            }
        }

        public void Add(TValue item)
        {
            _array.Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TValue item)
        {
            return -1 < IndexOf(item);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _array.Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(TValue item)
        {
            return _array.Remove(item);
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return _array.Select(o => (TValue)Activator.CreateInstance(typeof(TValue), new object[] { o })).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.Select(o => (TValue)Activator.CreateInstance(typeof(TValue), new object[] { o })).GetEnumerator();
        }
    }
}
