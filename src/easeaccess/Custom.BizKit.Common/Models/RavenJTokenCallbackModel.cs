using Raven.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
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
