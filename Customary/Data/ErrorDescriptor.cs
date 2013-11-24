using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Json.Linq;

    public class ErrorDescriptor : NameDescriptor
    {
        private string _message;

        public ErrorDescriptor(string name, NameDescriptor parent, JsonDocument jsonDocument, string message)
            : base(name, parent)
        {
            _message = message;
        }

        public string Message
        {
            get { return _message; }
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Error; }
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            var result = new RavenJObject();

            result["message"] = _message;

            return result;
        }
    }
}