using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Text : Metadata
    {
        internal Text(RavenJObject metadata)
            : base(metadata)
        {
        }

        public string this[string culture]
        {
            get
            {
                RavenJToken value;
                if (_data.TryGetValue(culture, out value) && value != null && JTokenType.String.Equals(value.Type))
                    return (string)((RavenJValue)value).Value;
                return null;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    _data.Remove(culture);
                else
                    _data[culture] = new RavenJValue(value);
            }
        }
    }
}