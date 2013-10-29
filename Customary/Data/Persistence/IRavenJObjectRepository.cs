using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Raven.Json.Linq;

    public interface IRavenJObjectRepository
    {
        IRavenJObjectCatalog Store { get; }

        RavenJObject Read(int skip, int take);

        RavenJObject Read(Guid id);

        RavenJObject Create(RavenJObject value);

        RavenJObject Update(Guid id, RavenJObject value);

        RavenJObject Patch(Guid id, RavenJObject value);

        RavenJObject Delete(Guid id);
    }
}