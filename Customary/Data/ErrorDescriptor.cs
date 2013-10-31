using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

    public class ErrorDescriptor : NameDescriptor
    {
        public ErrorDescriptor(string name, NameDescriptor parent, JsonDocument jsonDocument, string message)
            : base(name, parent)
        {
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Error; }
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            throw new NotImplementedException();
        }
    }
}