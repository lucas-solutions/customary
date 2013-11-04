using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    public class ModelDictionary
    {
        private readonly ConcurrentDictionary<Guid, string> _knownPaths;

        public ModelDictionary()
        {
            _knownPaths = new ConcurrentDictionary<Guid, string>();
        }

        public string this[Guid key]
        {
            get
            {
                string name;
                return _knownPaths.TryGetValue(key, out name) ? name : null;
            }
            set
            {
                _knownPaths.AddOrUpdate(key, value, (id, name) => { return value; });
            }
        }
    }
}