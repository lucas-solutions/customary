using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    /// <summary>
    /// Not the business not the presentation should have any knowledge about persistence.
    /// So, it shouldn't even have knowledge of the database type or location for a given entity type.
    /// So, it shouldn't even have knowledge of the store  or store context being used.
    /// The client context has the information to figure that out.
    /// All the business should do is EntitySet<T>().Save(T entities) or EntitySet<T>().Save(IEnumerable<T> entities).
    /// Similar would be for Load: T EntitySet<T>().Load(Guid id)
    /// </summary>
    public class ClientContext
    {
        [ThreadStatic]
        private static ClientContext _current;

        public static ClientContext Current
        {
            get
            {
                return _current ?? (_current = ResolveCurrentContext());
            }
        }

        private ClientContext()
        {
        }

        public EntitySet<T> EntitySet<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        private static ClientContext ResolveCurrentContext()
        {
            throw new NotImplementedException();
        }
    }
}