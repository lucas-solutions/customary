using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Raven.Json.Linq;

    public class RavenJTokenCallbackModel
    {
        public RavenJToken Token { get; set; }

        public string Id { get; set; }

        public int Index { get; set; }

        public int? Position { get; set; }
    }

    public class RavenJTokenCallbackModel<T> : RavenJTokenCallbackModel
    {
        public T Value { get; set; }
    }
}