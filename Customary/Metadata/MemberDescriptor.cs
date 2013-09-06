using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Metadata
{
    using Custom.Metadata;
    using Newtonsoft.Json;
    using Raven.Json.Linq;

    [JsonObject(IsReference = true)]
    public class MemberDescriptor
    {
        private TextObject _title;
        private TextObject _summary;

        public virtual string Name
        {
            get;
            set;
        }

        public MemberTypes MemberType
        {
            get;
            set;
        }

        public TextObject Title
        {
            get { return _title ?? (_title = new TextObject()); }
            set { _title = value; }
        }

        public TextObject Summary
        {
            get { return _summary ?? (_summary = new TextObject()); }
            set { _summary = value; }
        }
    }
}