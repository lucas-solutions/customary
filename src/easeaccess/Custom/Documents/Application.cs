using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Custom.Objects;
    using Raven.Json.Linq;

    public class Application : Document<ApplicationObject>
    {
        private Collection<Area> _areas;

        public Application(RavenJObject value, Master master)
            : base(value)
        {
        }

        public string Host
        {
            get { return _value.Value<string>("Host"); }
            set { _value["Host"] = value; }
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
