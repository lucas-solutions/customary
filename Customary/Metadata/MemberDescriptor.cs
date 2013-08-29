using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Metadata
{
    using Custom.Objects;
    using Newtonsoft.Json;
    using Raven.Json.Linq;

    [JsonObject(IsReference = true)]
    public class MemberDescriptor
    {
        public string Name { get; set; }

        public MemberTypes MemberType { get; set; }

        public TextObject Title { get; set; }
    }
}