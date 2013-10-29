using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;

    public interface IRavenJObjectCatalog
    {
        string Name { get; }

        string ConnectionString { get; }

        IRavenJObjectRepository ResolveRepository(EntityDefinition definition);
    }
}