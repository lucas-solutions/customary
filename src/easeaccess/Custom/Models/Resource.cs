using Raven.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public abstract class Resource
    {
        protected readonly RavenJObject _data;

        protected Resource(RavenJObject data)
        {
            _data = data;
        }

        public abstract string Set
        {
            get;
        }
    }
}