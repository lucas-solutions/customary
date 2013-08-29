using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Raven.Client;
    using Raven.Json.Linq;

    /// <summary>
    /// A business object usually does nothing itself but holds a set of instance variables or properties.
    /// See also:
    /// Active record pattern
    /// Data access object
    /// Data transfer object
    /// </summary>
    public class BusinessObject
    {
        internal readonly RavenJObject _data;
        internal readonly EntityDescriptor _descriptor;

        internal BusinessObject(RavenJObject data, EntityDescriptor descriptor)
        {
            _data = data;
            _descriptor = descriptor;
        }
    }
}