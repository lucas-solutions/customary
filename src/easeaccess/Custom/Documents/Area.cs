using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Custom.Objects;
    using Raven.Client.Indexes;
    using Raven.Json.Linq;

    public class Area : Component
    {
        private readonly Area _parent;
        private readonly Application _application;
        private Collection<Area> _areas;

        public Area(RavenJObject value, Area parent)
            : base(value)
        {
            _parent = parent;
            _application = parent._application;
        }

        public Area(RavenJObject value, Application application)
            : base(value)
        {
            _application = application;
            _parent = null;
        }

        public Application Application
        {
            get { return _application; }
        }

        public Area Parent
        {
            get { return _parent; }
        }

        public string Path
        {
            get { return (_parent != null ? _parent.Path : "Applications/" + _application.Host) + '/' + Id; }
        }

        public Collection<Area> Areas
        {
            get
            {
                if (_areas == null)
                {
                    var array = _value.Value<RavenJArray>("Areas");

                    if (array == null)
                    {
                        array = new RavenJArray();
                        _value["Areas"] = array;
                    }

                    _areas = new Collection<Area>("Name", array, this);
                }

                return _areas;
            }
        }
    }
}
