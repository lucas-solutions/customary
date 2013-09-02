using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.ComponentModel
{
    using Raven.Json.Linq;

    public class DocumentPropertyDescriptor : IPropertyDescriptor
    {
        public DocumentPropertyDescriptor(RavenJObject o)
        {
        }
    }
}