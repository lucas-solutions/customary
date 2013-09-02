using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    /// <summary>
    /// Table-Table Relationship
    /// </summary>
    public class Relationship : Metadata<RelationshipObject>
    {
        public Relationship(RavenJObject data, Master parent, string path)
            : base(data)
        {
        }
    }
}