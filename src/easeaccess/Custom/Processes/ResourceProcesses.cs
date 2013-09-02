using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Processes
{
    using Custom.Objects;
    using Custom.Resources;

    public abstract class ResourceProcesses<TResource>
        where TResource : Resource
    {
        private readonly TResource _resource;

        protected ResourceProcesses(TResource resource)
        {
            _resource = resource;
        }

        public TResource Resource
        {
            get { return _resource; }
        }
    }

    public abstract class ResourceProcesses<TResource, TObject> : ResourceProcesses<TResource>
        where TResource : Resource<TObject>
        where TObject : Metadata
    {
        protected ResourceProcesses(Resource resource)
            : base(resource)
        {
        }
    }

    public abstract class ResourceProcesses<TResource, TObject, TParent> : ResourceProcesses<TResource, TObject>
        where TResource : Resource<TObject, TParent>
        where TObject : Metadata
        where TParent : Resource
    {
        protected ResourceProcesses(TResource resource)
            : base(resource)
        {
        }
    }
}