using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Models
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Area
    {
        private readonly Area _parent;
        protected readonly RavenJObject _fragment;

        public Area(RavenJObject fragment, Area parent)
        {
            _fragment = fragment;
            _parent = parent;
        }

        protected Area(RavenJObject fragment)
        {
            _fragment = fragment;
            _parent = null;
        }

        public IEnumerable<Area> Areas
        {
            get { return _fragment["Areas"].Values().Where(o => JTokenType.Object.Equals(o.Type)).Select(o => new Area(o as RavenJObject, this)); }
        }

        public virtual Master Master
        {
            get { return Parent.Master; }
        }

        public string Name
        {
            get { return _fragment.Value<string>("Name"); }
            set { _fragment["Name"] = value; }
        }

        public Area Parent
        {
            get { return _parent; }
        }

        public virtual string Path
        {
            get { return Parent.Path + "Areas" + Name; }
        }

        public string Reource
        {
            get { return _fragment.Value<string>("Resource"); }
            set { _fragment["Resource"] = value; }
        }

        public Service Service
        {
            get { return new Service(this); }
        }

        public RavenJObject FetchArea(string name)
        {
            var array = _fragment.Value<RavenJArray>("Name");
            return null != array ? array.OfType<RavenJObject>().FirstOrDefault(o => o.Value<string>("Name") == name) : null;
        }

        public void StoreArea(string name, RavenJObject fragment)
        {
            var array = _fragment.Value<RavenJArray>("Areas");

            RavenJObject value = null;

            if (array != null)
                value = array.OfType<RavenJObject>().FirstOrDefault(o => o.Value<string>("Name") == name);
            else
                _fragment["Areas"] = array = new RavenJArray();

            if (value != null)
            {
                // merge
            }
            else
                array.Add(fragment);
        }

        public void RemoveArea(string name)
        {
            var array = _fragment.Value<RavenJArray>("Areas");

            RavenJObject value = null;

            if (array != null)
            {
                value = array.OfType<RavenJObject>().FirstOrDefault(o => o.Value<string>("Name") == name);

                if (value 
            }
        }

        public LookupResult Lookup(Lookup lookup)
        {
            if (lookup.Path.Count.Equals(0))
                return null;

            Area area;

            var name = lookup.Path.Pop();

            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();

                if ("Areas".Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    area = GetArea(name);

                if (area != null)
                    return Value(area.Lookup(lookup), area);

                lookup.Path.Push(name);
                name = segment;
            }

            component = GetArea(name);

            if (component != null)
                return Value(component.Lookup(lookup), area);

            lookup.Path.Push(name);

            return null;
        }

        public Area GetArea(string name)
        {
            var array = _data.Value<RavenJArray>("Areas");
            var item = array != null ? array.SingleOrDefault(o => name == o.Value<string>("Name")) as RavenJObject : null;
            return item != null ? new Area(item, this) : null;
        }

        public Area SetArea(string name, RavenJObject value)
        {
            var array = _data.Value<RavenJArray>("Areas");
            var item = array != null ? array.SingleOrDefault(o => name == o.Value<string>("Name")) as RavenJObject : null;
            return item != null ? new Area(item, this) : null;
        }
    }
}