using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.ComponentModel
{
    using Custom.DocumentModel;
    using Raven.Json.Linq;

    public class DocumentTypeDescriptor : Document, ITypeDescriptor
    {
        static readonly ReflectionTypeDescriptor _propertyDescriptor;

        static DocumentTypeDescriptor()
        {
            _propertyDescriptor = new ReflectionTypeDescriptor();
        }

        public DocumentTypeDescriptor(RavenJObject o, Master master)
            : base(o, master)
        {
        }
    }
}