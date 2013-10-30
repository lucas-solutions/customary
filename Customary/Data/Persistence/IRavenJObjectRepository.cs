using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Raven.Json.Linq;

    public interface IRavenJObjectRepository
    {
        RavenJObject Read(int skip, int take);

        RavenJObject Read(Guid id);

        RavenJObject Create(RavenJObject value);

        RavenJObject Update(Guid id, RavenJObject value, bool patch);

        RavenJObject Delete(Guid id);
    }
}