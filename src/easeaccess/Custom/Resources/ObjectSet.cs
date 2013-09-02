using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;

    public class ObjectSet<TObject> : IList<TObject>
        where TObject : class
    {
        private readonly IList<TObject> _list;

        public ObjectSet(Master master)
        {
            _list = list;
        }

        public int IndexOf(TResource item)
        {
            return _list.IndexOf(item.Object);
        }

        public void Insert(int index, TResource item)
        {
            _list.Insert(index, item.Object);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public TResource this[int index]
        {
            get
            {
                return new TResource { Object = _list[index]; }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(TResource item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TResource item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TResource[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(TResource item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TResource> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}