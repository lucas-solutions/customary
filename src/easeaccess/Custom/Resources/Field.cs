using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Field : Metadata<FieldObject>
    {
        public readonly Form _form;

        public Field(RavenJObject data, Form form)
            : base(data)
        {
            _form = form;
        }

        public Form Form
        {
            get { return _form; } 
        }

        public string Property
        {
            get;
            set;
        }
    }
}