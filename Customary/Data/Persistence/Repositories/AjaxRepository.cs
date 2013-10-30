using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Repositories
{
    using Raven.Json.Linq;

    public class AjaxRepository : IRavenJObjectRepository
    {
        public RavenJObject Read(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public RavenJObject Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public RavenJObject Create(RavenJObject value)
        {
            throw new NotImplementedException();
        }

        public RavenJObject Update(Guid id, RavenJObject value, bool patch)
        {
            throw new NotImplementedException();
        }

        public RavenJObject Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}